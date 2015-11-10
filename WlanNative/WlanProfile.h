//Samples written by Chris Lewis

#include "Stdafx.h"

#pragma once

using namespace System;

namespace WlanNative
{

    public ref class WlanProfile
    {
    public:
        property bool UserProfile 
        { 
            bool get()
            {
                return (flags & WLAN_PROFILE_USER) == WLAN_PROFILE_USER;
            } 
        }
        property bool GroupPolicyProfile
        {
            bool get()
            {
                return (flags & WLAN_PROFILE_GROUP_POLICY) == WLAN_PROFILE_GROUP_POLICY;
            }
        }
        property String^ ProfileName
        {
            String^ get()
            {
                if (String::IsNullOrEmpty(profileName)) return nullptr;
                return gcnew String(profileName);
            }
        }
        WlanProfile()
        {
        }
    internal:
        WlanProfile(WLAN_PROFILE_INFO* pInfo, IntPtr hWlan)
        {
            if (pInfo)
            {
                flags = pInfo->dwFlags;
                profileName = gcnew String(pInfo->strProfileName);
            }
            handle = hWlan;
        }

        //Utility functions to convert from managed to unmanaged GUID or vice versa
        static void ConvertNative(Guid^ managedGuid, LPGUID nativeGuid)
        {
            if (managedGuid && nativeGuid)
            {
                array<unsigned char>^ ppArray = managedGuid->ToByteArray();
                pin_ptr<unsigned char> pp = &ppArray[0];
                memcpy(nativeGuid, pp, sizeof(GUID));
            }
        }
        static void ConvertManaged(LPGUID nativeGuid, interior_ptr<Guid^> managedGuid)
        {
            if (managedGuid && nativeGuid)
            {
                *managedGuid = gcnew Guid(nativeGuid->Data1, nativeGuid->Data2, nativeGuid->Data3, nativeGuid->Data4[0], nativeGuid->Data4[1], nativeGuid->Data4[2], nativeGuid->Data4[3], nativeGuid->Data4[4], nativeGuid->Data4[5], nativeGuid->Data4[6], nativeGuid->Data4[7]);
            }
        }
    private:
        int flags;
        String^ profileName;
        IntPtr handle;
    };
}