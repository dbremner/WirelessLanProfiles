//Samples written by Chris Lewis
#include "Stdafx.h"
#include "WlanProfile.h"
#include "WlanRadio.h"
#include "WlanNetwork.h"

#pragma once

using namespace System;

namespace WlanNative
{
    //Represents a crypto or auth pair set
    [System::ComponentModel::TypeConverter(WlanAuthCipherProperty::typeid)]
    public ref class WlanAuthCipherProperty : public System::ComponentModel::ExpandableObjectConverter
    {
    public:
        property String^ AuthType { String^ get()
        {
            return gcnew String(authType);
        }
        void set(String^ authtype)
        {
            authType = gcnew String(authtype);
        }
        }

        property array<String^>^ CipherTypes { array<String^>^ get()
        {
            return cipherTypes;
        }
        void set(array<String^>^ ciphertypes)
        {
            cipherTypes = ciphertypes;
        }
        }
    private:
        String^ authType;
        array<String^>^ cipherTypes;
    };

    //Represents a single wireless lan interface
    [System::ComponentModel::TypeConverter(WlanInterface::typeid)]
    public ref class WlanInterface : public WlanCommonFuncs
    {
    public:
        WlanInterface()
        {
        }
        WlanInterface(WLAN_INTERFACE_INFO* info, IntPtr hWlan)
        {
            WlanProfile::ConvertManaged(&info->InterfaceGuid, &guid);
            description = gcnew String(info->strInterfaceDescription);
            state = info->isState;
            handle = hWlan;
            PWLAN_INTERFACE_CAPABILITY pWic;
            DWORD result = WlanGetInterfaceCapability((HANDLE)(void*)handle, &info->InterfaceGuid, nullptr, &pWic);
            if (result != ERROR_SUCCESS)
            {
                System::Runtime::InteropServices::Marshal::ThrowExceptionForHR(HRESULT_FROM_WIN32(result));
            }
            capabilities = (IntPtr)(void*)pWic;
        }

        ~WlanInterface()
        {
            void* pC = (void*)capabilities;
            if (pC)
            {
                WlanFreeMemory(pC);
                capabilities = (IntPtr)NULL;
            }
        }
        //Scans for networks
        //Note that this returns immediately; you'll need to be notified of changes to see when it finishes
        void ScanForNetworks()
        {
            GUID g;
            WlanProfile::ConvertNative(guid, &g);
            DWORD result = WlanScan((HANDLE)(void*)handle, &g, NULL, NULL, nullptr);
            if (result != ERROR_SUCCESS)
            {
                System::Runtime::InteropServices::Marshal::ThrowExceptionForHR(HRESULT_FROM_WIN32(result));
            }
        }
        //Returns the available networks from the current list
        System::Collections::Generic::List<WlanNetwork^>^ GetAvailableNetworks(bool adhoc, bool hidden)
        {
            
            PWLAN_AVAILABLE_NETWORK_LIST nlist;
			GUID g;
            WlanProfile::ConvertNative(guid, &g);
            DWORD flags = 0;
            if (adhoc)
            {
                flags += WLAN_AVAILABLE_NETWORK_INCLUDE_ALL_ADHOC_PROFILES;
            }
            if (hidden)
            {
                flags += WLAN_AVAILABLE_NETWORK_INCLUDE_ALL_MANUAL_HIDDEN_PROFILES;
            }
            DWORD result = WlanGetAvailableNetworkList((HANDLE)(void*)handle, &g, 3, NULL, &nlist); 
            if (result != ERROR_SUCCESS)
            {
                System::Runtime::InteropServices::Marshal::ThrowExceptionForHR(HRESULT_FROM_WIN32(result));
            }

            for (int i = 0; i < nlist->dwNumberOfItems; i++)
            auto networks = gcnew System::Collections::Generic::List<WlanNetwork^>();
            {
                networks->Add(gcnew WlanNetwork(&nlist->Network[i]));
            }
            Free(nlist);
            return networks;
        }

        void SetProfileEAPXmlUserData(String^ profileName, String^ userData, bool allUsers)
        {
            GUID g;
            WlanProfile::ConvertNative(guid, &g);
            pin_ptr<const wchar_t> xml = PtrToStringChars(userData);
            pin_ptr<const wchar_t> name = PtrToStringChars(profileName);
            DWORD result = WlanSetProfileEapXmlUserData((HANDLE)(void*)handle, &g, name, allUsers ? 1 : 0, xml, nullptr);
            if (result != ERROR_SUCCESS)
            {
                System::Runtime::InteropServices::Marshal::ThrowExceptionForHR(HRESULT_FROM_WIN32(result));
            }
        }

        void Connect(bool secure)
        {
            WLAN_CONNECTION_PARAMETERS parameters;
            ZeroMemory(&parameters, sizeof(WLAN_CONNECTION_PARAMETERS));
            parameters.wlanConnectionMode = secure ? WLAN_CONNECTION_MODE::wlan_connection_mode_discovery_secure : WLAN_CONNECTION_MODE::wlan_connection_mode_discovery_unsecure;
			parameters.strProfile = nullptr;
			parameters.pDot11Ssid = nullptr;
            parameters.pDesiredBssidList = nullptr;
            parameters.dot11BssType = DOT11_BSS_TYPE::dot11_BSS_type_any;
            Connect(&parameters);
        }
        void Connect(WlanProfile^ profile)
        {
            WLAN_CONNECTION_PARAMETERS parameters;
            pin_ptr<const wchar_t> name = PtrToStringChars(profile->ProfileName);

            ZeroMemory(&parameters, sizeof(WLAN_CONNECTION_PARAMETERS));
            parameters.wlanConnectionMode = WLAN_CONNECTION_MODE::wlan_connection_mode_profile;
            parameters.strProfile = name;
			parameters.pDot11Ssid = nullptr;
			parameters.pDesiredBssidList = nullptr;
            parameters.dot11BssType = DOT11_BSS_TYPE::dot11_BSS_type_any; //This would actually need to be modified if there was something different in the profile
            Connect(&parameters);
        }
        void Connect(String^ xmlTempProfile)
        {
            WLAN_CONNECTION_PARAMETERS parameters;
            pin_ptr<const wchar_t> name = PtrToStringChars(xmlTempProfile);

            ZeroMemory(&parameters, sizeof(WLAN_CONNECTION_PARAMETERS));
            parameters.wlanConnectionMode = WLAN_CONNECTION_MODE::wlan_connection_mode_temporary_profile;
            parameters.strProfile = name;
            parameters.pDot11Ssid = nullptr;
			parameters.pDesiredBssidList = nullptr;
            parameters.dot11BssType = DOT11_BSS_TYPE::dot11_BSS_type_any; //This would actually need to be modified if there was something different in the profile
            Connect(&parameters);
        }

        System::Collections::Generic::List<WlanProfile^>^ GetProfiles()
        {
            if (guid == nullptr) return nullptr;
            GUID g;
            PWLAN_PROFILE_INFO_LIST pProfiles;
            WlanProfile::ConvertNative(guid, &g);
            DWORD result = WlanGetProfileList((HANDLE)(void*)handle, &g, nullptr, &pProfiles);
            if (result != ERROR_SUCCESS)
            {
                System::Runtime::InteropServices::Marshal::ThrowExceptionForHR(HRESULT_FROM_WIN32(result));
            }
            auto profiles = gcnew System::Collections::Generic::List<WlanProfile^>();
            for (DWORD index = 0; index < pProfiles->dwNumberOfItems; index++)
            {
                auto wp = gcnew WlanProfile(&pProfiles->ProfileInfo[index], handle);
                if (wp != nullptr)
                {
                    profiles->Add(wp);
                }
            }
            Free(pProfiles);
            return profiles;
        }
        //Gets the XML of a profile
        String^ GetProfile(WlanProfile^ profile)
        {
            GUID g;
            DWORD flags, access;
            LPWSTR profileXML;
            pin_ptr<const wchar_t> pName = PtrToStringChars(profile->ProfileName);
            WlanProfile::ConvertNative(guid, &g);
            DWORD result = WlanGetProfile((HANDLE)(void*)handle, &g, pName, nullptr, &profileXML, &flags, &access);
            if (result != ERROR_SUCCESS)
            {
                System::Runtime::InteropServices::Marshal::ThrowExceptionForHR(HRESULT_FROM_WIN32(result));
            }
            auto returnValue = gcnew String(profileXML);
            Free(profileXML);
            return returnValue;
        }

        //Assumes all users, no specified security desciptor, and overwrite
        void SetProfile(WlanProfile^ profile, String^ profileXML)
        {
            GUID g;
            DWORD reason;
            pin_ptr<const wchar_t> pXML = PtrToStringChars(profileXML);
            WlanProfile::ConvertNative(guid, &g);
            DWORD result = WlanSetProfile((HANDLE)(void*)handle, &g, 0, pXML, NULL, TRUE, nullptr, &reason);
            if (result != ERROR_SUCCESS)
            {
                if (result == ERROR_BAD_PROFILE)
                {
                    DWORD bufferSize = 4096;
                    wchar_t* buffer = (wchar_t*)malloc(bufferSize);
                    if (buffer)
                    {
                        if (WlanReasonCodeToString(reason, bufferSize, buffer, nullptr) == ERROR_SUCCESS)
                        {
                            free(buffer);
                            auto spException = gcnew Exception(gcnew String(buffer));
                            throw spException;
                        }
                        free(buffer);
                    }
                }
                System::Runtime::InteropServices::Marshal::ThrowExceptionForHR(HRESULT_FROM_WIN32(result));
            }
        }
        //Disconnects the network
        void Disconnect()
        {
            GUID g;
            WlanProfile::ConvertNative(guid, &g);
            DWORD result = WlanDisconnect((HANDLE)(void*)handle, &g, nullptr);
            if (result != ERROR_SUCCESS)
            {
                System::Runtime::InteropServices::Marshal::ThrowExceptionForHR(HRESULT_FROM_WIN32(result));
            }
        }
        //Shows the dialog that lets the user edit the network
        int ShowEditProfileDialog(WlanProfile^ profile, IntPtr hwnd)
        {
            WLAN_REASON_CODE code;
            GUID g;
            pin_ptr<const wchar_t> name = PtrToStringChars(profile->ProfileName);
            WlanProfile::ConvertNative(guid, &g);
            DWORD result = WlanUIEditProfile(WLAN_UI_API_VERSION, name, &g, (HWND)(void*)hwnd, WL_DISPLAY_PAGES::WLConnectionPage, nullptr, &code);
            if (result != ERROR_SUCCESS)
            {
                System::Runtime::InteropServices::Marshal::ThrowExceptionForHR(HRESULT_FROM_WIN32(result));
            }
            return code;
        }
        //GUID for the interface
        property Guid^ InterfaceGuid
        {
            Guid^ get()
            {
                if (guid == nullptr)
                {
                    return gcnew Guid();
                }
                return guid;
            }
        }
        //Description for the interface
        property String^ Description
        {
            String^ get()
            {
                return gcnew String(description);
            }
        }

        //Returned value from WlanQueryInterface
        property bool AutoConfigurationEnabled
        {
            bool get()
            {
                BOOL* data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_autoconf_enabled, (void**)&data, &dataSize, &valueType)) return false;
                if (dataSize != sizeof(BOOL)) return false;
                bool result = *data ? true : false;
                Free(data);
                return result;
            }
        }

        //Returned value from WlanQueryInterface
        property bool BackgroundScanEnabled
        {
            bool get()
            {
                BOOL* data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_background_scan_enabled, (void**)&data, &dataSize, &valueType)) return false;
                if (dataSize != sizeof(BOOL)) return false;
                bool result = *data ? true : false;
                Free(data);
                return result;
            }
        }

        //Returned value from WlanQueryInterface
        property array<WlanRadioState^>^ RadioStates
        {
            array<WlanRadioState^>^ get()
            {
                auto states = gcnew System::Collections::Generic::List<WlanRadioState^>();

                WLAN_RADIO_STATE * data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_radio_state, (void**)&data, &dataSize, &valueType)) return states->ToArray();
                if (dataSize != sizeof(WLAN_RADIO_STATE)) return states->ToArray();
                WLAN_INTERFACE_CAPABILITY* caps = (WLAN_INTERFACE_CAPABILITY*)(void*)capabilities;
                for (int i = 0; i < data->dwNumberOfPhys; i++)
                {
                    WLAN_PHY_RADIO_STATE rs = data->PhyRadioState[i];
                    states->Add(gcnew WlanRadioState(&rs, caps));
                }
                Free(data);
                return states->ToArray();
            }
        }

        //Returned value from WlanQueryInterface
        property String^ BSSType
        {
            String^ get()
            {
                _DOT11_BSS_TYPE* data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_bss_type, (void**)&data, &dataSize, &valueType)) return gcnew String("Error");
                if (dataSize != sizeof(_DOT11_BSS_TYPE)) return gcnew String("Error");
                _DOT11_BSS_TYPE result = *data;
                Free(data);
                switch (result)
                {
                    case _DOT11_BSS_TYPE::dot11_BSS_type_infrastructure:
                        return gcnew String("Infrastructure");
                    case _DOT11_BSS_TYPE::dot11_BSS_type_independent:
                        return gcnew String("Independent");
                    case _DOT11_BSS_TYPE::dot11_BSS_type_any:
                        return gcnew String("Any");
                    default:
                        return gcnew String("Unknown");
                }
            }
        }

        //Returned value from WlanQueryInterface
        property String^ InterfaceState
        {
            String^ get()
            {
                WLAN_INTERFACE_STATE * data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_interface_state, (void**)&data, &dataSize, &valueType)) return gcnew String("Error");
                if (dataSize != sizeof(WLAN_INTERFACE_STATE)) return gcnew String("Error");
                WLAN_INTERFACE_STATE  result = *data;
                Free(data);
                switch (result)
                {
                    case WLAN_INTERFACE_STATE::wlan_interface_state_ad_hoc_network_formed:
                        return gcnew String("Ad Hoc Network Formed");
                    case WLAN_INTERFACE_STATE::wlan_interface_state_associating:
                        return gcnew String("Associating");
                    case WLAN_INTERFACE_STATE::wlan_interface_state_authenticating:
                        return gcnew String("Authenticating");
                    case WLAN_INTERFACE_STATE::wlan_interface_state_connected:
                        return gcnew String("Connected");
                    case WLAN_INTERFACE_STATE::wlan_interface_state_disconnected:
                        return gcnew String("Disconnected");
                    case WLAN_INTERFACE_STATE::wlan_interface_state_disconnecting:
                        return gcnew String("Disconnecting");
                    case WLAN_INTERFACE_STATE::wlan_interface_state_discovering:
                        return gcnew String("Discovering");
                    case WLAN_INTERFACE_STATE::wlan_interface_state_not_ready:
                        return gcnew String("Not Ready");
                    default:
                        return gcnew String("Unknown");
                }
            }
        }

        //Returned value from WlanQueryInterface
        property String^ CurrentConnectedProfile
        {
            String^ get()
            {
                WLAN_CONNECTION_ATTRIBUTES * data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_current_connection, (void**)&data, &dataSize, &valueType)) return gcnew String("Error");
                if (dataSize != sizeof(WLAN_CONNECTION_ATTRIBUTES)) return gcnew String("Error");
                auto result = gcnew String(data->strProfileName);
                Free(data);
                return result;
            }
        }

        //Returned value from WlanQueryInterface
        property String^ CurrentAuthAlgorithm
        {
            String^ get()
            {
                WLAN_CONNECTION_ATTRIBUTES * data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_current_connection, (void**)&data, &dataSize, &valueType)) return gcnew String("Error");
                if (dataSize != sizeof(WLAN_CONNECTION_ATTRIBUTES)) return gcnew String("Error");
                String^ result = TranslateAuth(data->wlanSecurityAttributes.dot11AuthAlgorithm);
                Free(data);
                return result;
            }
        }

        //Returned value from WlanQueryInterface
        property String^ CurrentCipherAlgorithm
        {
            String^ get()
            {
                WLAN_CONNECTION_ATTRIBUTES * data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_current_connection, (void**)&data, &dataSize, &valueType)) return gcnew String("Error");
                if (dataSize != sizeof(WLAN_CONNECTION_ATTRIBUTES)) return gcnew String("Error");
                String^ result = TranslateCipher(data->wlanSecurityAttributes.dot11CipherAlgorithm);
                Free(data);
                return result;
            }
        }

        //Returned value from WlanQueryInterface
        property bool OneXEnabled
        {
            bool get()
            {
                WLAN_CONNECTION_ATTRIBUTES * data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_current_connection, (void**)&data, &dataSize, &valueType)) return false;
                if (dataSize != sizeof(WLAN_CONNECTION_ATTRIBUTES)) return false;
                bool result = data->wlanSecurityAttributes.bOneXEnabled ? true : false;
                Free(data);
                return result;
            }
        }

        //Returned value from WlanQueryInterface
        property bool SecurityEnabled
        {
            bool get()
            {
                WLAN_CONNECTION_ATTRIBUTES * data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_current_connection, (void**)&data, &dataSize, &valueType)) return false;
                if (dataSize != sizeof(WLAN_CONNECTION_ATTRIBUTES)) return false;
                bool result = data->wlanSecurityAttributes.bSecurityEnabled ? true : false;
                Free(data);
                return result;
            }
        }

        //Returned value from WlanQueryInterface
        property int ChannelNumber
        {
            int get()
            {
                int* data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_channel_number, (void**)&data, &dataSize, &valueType)) return false;
                if (dataSize != sizeof(int)) return false;
                int result = *data;
                Free(data);
                return result;
            }
        }

        //Returned value from WlanQueryInterface
        property array<WlanAuthCipherProperty^>^ InfrastructureCipherPairs
        {
            array<WlanAuthCipherProperty^>^ get()
            {
                auto results = gcnew System::Collections::Generic::Dictionary<String^, System::Collections::Generic::List<String^>^>();
                WLAN_AUTH_CIPHER_PAIR_LIST * data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_supported_infrastructure_auth_cipher_pairs, (void**)&data, &dataSize, &valueType)) return ConvertDictionary(results);
                AddCipherAuthPairs(data, results);
                Free(data);
                return ConvertDictionary(results);
            }
        }
        property array<WlanAuthCipherProperty^>^ AdHocCipherPairs
        {
            array<WlanAuthCipherProperty^>^ get()
            {
                auto results = gcnew System::Collections::Generic::Dictionary<String^, System::Collections::Generic::List<String^>^>();
                WLAN_AUTH_CIPHER_PAIR_LIST * data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_supported_adhoc_auth_cipher_pairs, (void**)&data, &dataSize, &valueType)) return ConvertDictionary(results);
                AddCipherAuthPairs(data, results);
                Free(data);
                return ConvertDictionary(results);
            }
        }

        //Returned value from WlanQueryInterface
        property array<String^>^ SupportedCountriesAndRegions
        {
            array<String^>^ get()
            {
                auto results = gcnew System::Collections::Generic::List<String^>();
                WLAN_COUNTRY_OR_REGION_STRING_LIST* data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_supported_country_or_region_string_list, (void**)&data, &dataSize, &valueType)) return results->ToArray();
                for (int i = 0; i < data->dwNumberOfItems; i++)
                {
                    if (dataSize < (sizeof(WLAN_COUNTRY_OR_REGION_STRING_LIST)+(sizeof(DOT11_COUNTRY_OR_REGION_STRING)))) break;
                    results->Add(gcnew String((char*)data->pCountryOrRegionStringList[i],0,3));
                }
                Free(data);
                return results->ToArray();
            }
        }


        //Returned value from WlanQueryInterface
        property bool MediaStreamingMode
        {
            bool get()
            {
                BOOL* data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_media_streaming_mode, (void**)&data, &dataSize, &valueType)) return false;
                if (dataSize != sizeof(BOOL)) return false;
                bool result = *data ? true : false;
                Free(data);
                return result;
            }
        }


        //Returned value from WlanQueryInterface
        property int CurrentOperationMode
        {
            int get()
            {
                int* data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_current_operation_mode, (void**)&data, &dataSize, &valueType)) return false;
                if (dataSize != sizeof(int)) return false;
                int result = *data;
                Free(data);
                return result;
            }
        }


        //Returned value from WlanQueryInterface
        property int RSSI
        {
            int get()
            {
                int* data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_rssi, (void**)&data, &dataSize, &valueType)) return false;
                if (dataSize != sizeof(int)) return false;
                int result = *data;
                Free(data);
                return result;
            }
        }


        //Returned value from WlanQueryInterface
        property bool SupportedSafeMode
        {
            bool get()
            {
                BOOL* data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_supported_safe_mode, (void**)&data, &dataSize, &valueType)) return false;
                if (dataSize != sizeof(BOOL)) return false;
                bool result = *data ? true : false;
                Free(data);
                return result;
            }
        }


        //Returned value from WlanQueryInterface
        property bool CertifiedSafeMode
        {
            bool get()
            {
                BOOL* data;
                DWORD dataSize;
                WLAN_OPCODE_VALUE_TYPE valueType;
                if (!Query(wlan_intf_opcode_certified_safe_mode, (void**)&data, &dataSize, &valueType)) return false;
                if (dataSize != sizeof(BOOL)) return false;
                bool result = *data ? true : false;
                Free(data);
                return result;
            }
        }

    private:
        Guid^ guid;
        String^ description;
        int state;
        IntPtr handle;
        IntPtr capabilities;

        //Wraps WlanConnect
        void Connect(WLAN_CONNECTION_PARAMETERS* parameters)
        {
            GUID g;
            WlanProfile::ConvertNative(guid, &g);
            DWORD result = WlanConnect((HANDLE)(void*)handle, &g, parameters, nullptr);
            if (result != ERROR_SUCCESS)
            {
                System::Runtime::InteropServices::Marshal::ThrowExceptionForHR(HRESULT_FROM_WIN32(result));
            }
        }

        //Wraps WlanQueryInterface
        bool Query(WLAN_INTF_OPCODE opcode, void** ppData, DWORD* pDataSize, PWLAN_OPCODE_VALUE_TYPE valueType)
        {
            GUID g;
            WlanProfile::ConvertNative(guid, &g);
            DWORD result = WlanQueryInterface((HANDLE)(void*)handle, &g, opcode, nullptr, pDataSize, ppData, valueType);
            return result == ERROR_SUCCESS;
        }

        //Frees memory from the wlan service
        void Free(void* data)
        {
            WlanFreeMemory(data);
        }

        //Converts the easier to use dictionary to an array that a PropertyGrid control can use
        static array<WlanAuthCipherProperty^>^ ConvertDictionary(System::Collections::Generic::Dictionary<String^, System::Collections::Generic::List<String^>^>^ results)
        {
            auto a = gcnew array<WlanAuthCipherProperty^>(results->Count);
            int index = 0;
            for each (auto var in results->Keys)
            {
                a[index] = gcnew WlanAuthCipherProperty();
                a[index]->AuthType = var;
                a[index]->CipherTypes = results[var]->ToArray();
                index++;
            }
            return a;
        }


    };
}