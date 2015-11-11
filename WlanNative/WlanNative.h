// WlanNative.h

#include "Stdafx.h"
#include "WlanInterface.h"

#pragma once

using namespace System;
using namespace System::Collections::Generic;

//Callback function prototype that we'll use for notifications
void __stdcall WlanNotificationCallbackGlobal(PWLAN_NOTIFICATION_DATA data, void* context);
namespace WlanNative {
    //Class that will handle initial interop with the Wlan API
	public ref class WlanNative
	{

    private:
        IntPtr handle;

    public:
        WlanNative()
        {
            HANDLE h;
            DWORD version;
            //Subsequent code assumes that version two will always be available
            DWORD result = WlanOpenHandle(2, NULL, &version, &h);
            if (result != ERROR_SUCCESS)
            {
                System::Runtime::InteropServices::Marshal::ThrowExceptionForHR(HRESULT_FROM_WIN32(result));
            }
            handle = (IntPtr)h;
        }
        ~WlanNative()
        {
            void* h = (void*)handle;
            if (h)
            {
                UnregisterForNotifications(); //Close notifications just in case
                WlanCloseHandle(h, NULL);
                handle = (IntPtr)NULL;
            }
        }

        delegate void NotificationCallbackProc(PWLAN_NOTIFICATION_DATA data);

        delegate void NotificationProc(Guid^ interfaceGuid, String^ source, int code, int bufferSize, IntPtr buffer);

        event NotificationProc^ NotificationReceived;

        //Retrieves a list of interfaces
        List<WlanInterface^>^ GetInterfaces()
        {
            PWLAN_INTERFACE_INFO_LIST pInterfaces;
            DWORD result = WlanEnumInterfaces((HANDLE)(void*)handle, NULL, &pInterfaces);
            if (result != ERROR_SUCCESS)
            {
                System::Runtime::InteropServices::Marshal::ThrowExceptionForHR(HRESULT_FROM_WIN32(result));
            }
            List<WlanInterface^>^ interfaces = gcnew List<WlanInterface^>();
            for (DWORD index = 0; index < pInterfaces->dwNumberOfItems; index++)
            {
                WlanInterface^ wi = gcnew WlanInterface(&pInterfaces->InterfaceInfo[index], handle);
                if (wi != nullptr)
                {
                    interfaces->Add(wi);
                }
            }
            WlanFreeMemory(pInterfaces);
            return interfaces;
        }
        int RegisterForAllNotifications(bool allowDuplicates)
        {
            return RegisterForSpecificNotifications(WLAN_NOTIFICATION_SOURCE_ALL, allowDuplicates);
        }
        int RegisterForSpecificNotifications(unsigned int types, bool allowDuplicates)
        {
            DWORD old;
            if (proc == nullptr)
            {
                proc = gcnew NotificationCallbackProc(this, &WlanNative::NotificationCallback);
            }
            IntPtr context = System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(proc);
            DWORD result = WlanRegisterNotification((HANDLE)(void*)handle, types, allowDuplicates ? FALSE : TRUE, WlanNotificationCallbackGlobal, (void*)context, NULL, &old);
            if (result != ERROR_SUCCESS)
            {
                System::Runtime::InteropServices::Marshal::ThrowExceptionForHR(HRESULT_FROM_WIN32(result));
            }
            return old;
        }
        int UnregisterForNotifications()
        {
            return RegisterForSpecificNotifications(WLAN_NOTIFICATION_SOURCE_NONE, false);
        }

    internal:
        void NotificationCallback(PWLAN_NOTIFICATION_DATA data)
        {
            Guid^ g;
            String^ source;
            WlanProfile::ConvertManaged(&data->InterfaceGuid, &g);
            switch (data->NotificationSource)
            {
                case WLAN_NOTIFICATION_SOURCE_ACM:
                    source = gcnew String("Auto Configuration Module");
                    break;
                case WLAN_NOTIFICATION_SOURCE_ALL:
                case WLAN_NOTIFICATION_SOURCE_ONEX:
                    source = gcnew String("802.1X Module");
                    break;
                case WLAN_NOTIFICATION_SOURCE_IHV:
                    source = gcnew String("Independent Hardware Vendor Module");
                    break;
                case WLAN_NOTIFICATION_SOURCE_MSM:
                    source = gcnew String("Media Specific Module");
                    break;
                case WLAN_NOTIFICATION_SOURCE_SECURITY:
                    source = gcnew String("Security Module");
                    break;
                case WLAN_NOTIFICATION_SOURCE_HNWK:
                    source = gcnew String("Hosted Network Module");
                    break;
                case WLAN_NOTIFICATION_SOURCE_NONE:
                default:
                    source = gcnew String("Unknown Module");
                    break;
                    
            }
            NotificationReceived(g, source, data->NotificationCode, data->dwDataSize, (IntPtr)data->pData);
        }
    private:
        NotificationCallbackProc^ proc;
	};
}
typedef void(__stdcall *NotificationCallbackDataNativeProc)(PWLAN_NOTIFICATION_DATA data);
void __stdcall WlanNotificationCallbackGlobal(PWLAN_NOTIFICATION_DATA data, void* context)
{
    NotificationCallbackDataNativeProc proc = (NotificationCallbackDataNativeProc)context;
    if (proc)
    {
        proc(data);
    }
}