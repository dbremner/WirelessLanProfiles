//Samples written by Chris Lewis

#include "Stdafx.h"

#pragma once

using namespace System;

namespace WlanNative
{
    //Static functions used by a couple of classes
    public ref class WlanCommonFuncs : public System::ComponentModel::ExpandableObjectConverter
    {

    public:
        static String^ TranslateCipher(int cipher)
        {
            String^ result;
            switch (cipher)
            {
                case DOT11_CIPHER_ALGORITHM::DOT11_CIPHER_ALGO_BIP:
                    result = gcnew String("BIP");
                    break;
                case DOT11_CIPHER_ALGORITHM::DOT11_CIPHER_ALGO_CCMP:
                    result = gcnew String("CCMP");
                    break;
                case DOT11_CIPHER_ALGORITHM::DOT11_CIPHER_ALGO_NONE:
                    result = gcnew String("None");
                    break;
                case DOT11_CIPHER_ALGORITHM::DOT11_CIPHER_ALGO_RSN_USE_GROUP:
                    result = gcnew String("Group");
                    break;
                case DOT11_CIPHER_ALGORITHM::DOT11_CIPHER_ALGO_TKIP:
                    result = gcnew String("TKIP");
                    break;
                case DOT11_CIPHER_ALGORITHM::DOT11_CIPHER_ALGO_WEP:
                    result = gcnew String("WEP");
                    break;
                case DOT11_CIPHER_ALGORITHM::DOT11_CIPHER_ALGO_WEP104:
                    result = gcnew String("WEP 104");
                    break;
                case DOT11_CIPHER_ALGORITHM::DOT11_CIPHER_ALGO_WEP40:
                    result = gcnew String("WEP 40");
                    break;
                default:
                    result = gcnew String("Unknown");
            }
            return result;
        }

        static String^ TranslateAuth(int auth)
        {
            String^ result;
            switch (auth)
            {
                case DOT11_AUTH_ALGORITHM::DOT11_AUTH_ALGO_80211_OPEN:
                    result = gcnew String("802.11 Open");
                    break;
                case DOT11_AUTH_ALGORITHM::DOT11_AUTH_ALGO_80211_SHARED_KEY:
                    result = gcnew String("802.11 Shared Key");
                    break;
                case DOT11_AUTH_ALGORITHM::DOT11_AUTH_ALGO_RSNA:
                    result = gcnew String("RSNA");
                    break;
                case DOT11_AUTH_ALGORITHM::DOT11_AUTH_ALGO_RSNA_PSK:
                    result = gcnew String("RSNA PSK");
                    break;
                case DOT11_AUTH_ALGORITHM::DOT11_AUTH_ALGO_WPA:
                    result = gcnew String("WPA");
                    break;
                case DOT11_AUTH_ALGORITHM::DOT11_AUTH_ALGO_WPA_NONE:
                    result = gcnew String("WPA None");
                    break;
                case DOT11_AUTH_ALGORITHM::DOT11_AUTH_ALGO_WPA_PSK:
                    result = gcnew String("WPA PSK");
                    break;
                default:
                    result = gcnew String("Unknown");
            }
            return result;
        }

        static void AddCipherAuthPairs(WLAN_AUTH_CIPHER_PAIR_LIST* pairs, System::Collections::Generic::Dictionary<String^, System::Collections::Generic::List<String^>^>^ results)
        {
            for (int i = 0; i < pairs->dwNumberOfItems; i++)
            {
                DOT11_AUTH_CIPHER_PAIR pair = pairs->pAuthCipherPairList[i];
				auto auth = TranslateAuth(pair.AuthAlgoId);
                auto cipher = TranslateCipher(pair.CipherAlgoId);
                if (results->ContainsKey(auth))
                {
                    results[auth]->Add(cipher);
                }
                else
                {
                    auto l = gcnew System::Collections::Generic::List<String^>();
                    l->Add(cipher);
                    results->Add(auth, l);
                }
            }
        }
    };

    //Represents a single network-wraps _WLAN_AVAILABLE_NETWORK; see MSDN documentation for more information about the structure
    [System::ComponentModel::TypeConverter(WlanNetwork::typeid)]
    public ref class WlanNetwork : public WlanCommonFuncs
    {
    public:
        WlanNetwork()
        {
        }
        WlanNetwork(_WLAN_AVAILABLE_NETWORK* networkData)
        {
            _WLAN_AVAILABLE_NETWORK* newNetwork = (_WLAN_AVAILABLE_NETWORK*)malloc(sizeof(_WLAN_AVAILABLE_NETWORK));
            if (!newNetwork) throw gcnew OutOfMemoryException();
            memcpy(newNetwork, networkData, sizeof(_WLAN_AVAILABLE_NETWORK));
            network = (IntPtr)(void*)newNetwork;
        }
        ~WlanNetwork()
        {
            void* buffer = (void*)network;
            if (buffer)
            {
                free(buffer);
                network = (IntPtr)NULL;
            }
        }

        //Define the cast so we can just use n instead of the much longer text
        #define n ((_WLAN_AVAILABLE_NETWORK*)(void*)network)
        //Define the error for not initialized so we can just use the much smaller text
#define NI_Check if(!(void*)network) throw gcnew InvalidOperationException(gcnew String("Not Initialized"))

        property bool Connectable
        {
            bool get()
            {
                NI_Check;
                return n->bNetworkConnectable ? true : false;
            }
        }

        property bool SecurityEnabled
        {
            bool get()
            {
                NI_Check;
                return n->bSecurityEnabled ? true : false;
            }
        }

        property bool AdditionalPhysicalTypes
        {
            bool get()
            {
                NI_Check;
                return n->bMorePhyTypes ? true : false;
            }
        }

        property int NumberOfBSSIDs
        {
            int get()
            {
                NI_Check;
                return n->uNumberOfBssids;
            }
        }

        property String^ Name
        {
            String^ get()
            {
                NI_Check;
                return gcnew String(n->strProfileName);
            }
        }


        property String^ SSID
        {
            String^ get()
            {
                NI_Check;
                return gcnew String((const char*)n->dot11Ssid.ucSSID, 0, n->dot11Ssid.uSSIDLength);
            }
        }

        property String^ BSSType
        {
            String^ get()
            {
                NI_Check;
                switch (n->dot11BssType)
                {
                    case dot11_BSS_type_infrastructure:
                        return gcnew String("Infrastructure");
                    case dot11_BSS_type_independent:
                        return gcnew String("Independent");
                    case dot11_BSS_type_any:
                        return gcnew String("Any");
                    default:
                        return gcnew String("Unknown");
                }
            }
        }


        property String^ NotConnectableReason
        {
            String^ get()
            {
                NI_Check;
                if (!Connectable) return String::Empty;
                DWORD bufferSize = 4096;
                wchar_t* buffer = (wchar_t*)malloc(4096);
                if (!buffer) return String::Empty;
                if (WlanReasonCodeToString(n->wlanNotConnectableReason, bufferSize, buffer, nullptr) == ERROR_SUCCESS)
                {
                    free(buffer);
                    auto retString = gcnew String(buffer);
                    return retString;
                }
                free(buffer);
                return String::Empty;
            }
        }


        property String^ DefaultAuthAlgorithm
        {
            String^ get()
            {
                NI_Check;
                return TranslateAuth(n->dot11DefaultAuthAlgorithm);
            }
        }

        property String^ DefaultCipherAlgorithm
        {
            String^ get()
            {
                NI_Check;
                return TranslateCipher(n->dot11DefaultCipherAlgorithm);
            }
        }


        property String^ SignalStrength
        {
            String^ get()
            {
                NI_Check;
                return String::Format(L"{0}%", n->wlanSignalQuality);
            }
        }



    private:
        IntPtr network;
    };
}