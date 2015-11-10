//Samples written by Chris Lewis

#include "Stdafx.h"
#include "WlanProfile.h"

#pragma once

using namespace System;

namespace WlanNative
{
    //Represents a single radio state
    [System::ComponentModel::TypeConverter(WlanRadioState::typeid)]
    public ref class WlanRadioState : public System::ComponentModel::ExpandableObjectConverter
    {
    public:
        WlanRadioState(WLAN_PHY_RADIO_STATE* state, WLAN_INTERFACE_CAPABILITY* caps)
        {
            radioType = (int)caps->dot11PhyTypes[state->dwPhyIndex];
            sRadio = state->dot11SoftwareRadioState;
            hRadio = state->dot11HardwareRadioState;
        }

        WlanRadioState()
        {
        }

        property String^ RadioType
        {
            String^ get()
            {
                switch (radioType)
                {
                    case 1:
                        return gcnew String("FHSS");
                    case 2:
                        return gcnew String("DSSS");
                    case 3:
                        return gcnew String("IR Base Band");
                    case 4:
                        return gcnew String("OFDM");
                    case 5:
                        return gcnew String("HRDSSS");
                    case 6:
                        return gcnew String("ERP");
                    case 7:
                        return gcnew String("HT");
                    case 8:
                        return gcnew String("VHT");
                    default:
                        return gcnew String("Unknown");
                }
            }
        }
        property String^ SoftwareRadioState
        {
            String^ get()
            {
                return GetText(sRadio);
            }
        }

        property String^ HardwareRadioState
        {
            String^ get()
            {
                return GetText(hRadio);
            }
        }

    private:
        int radioType;
        int hRadio;
        int sRadio;
        String^ GetText(int radio)
        {
            switch (radio)
            {
                case DOT11_RADIO_STATE::dot11_radio_state_off:
                    return gcnew String("Off");
                case DOT11_RADIO_STATE::dot11_radio_state_on:
                    return gcnew String("On");
                default:
                    return gcnew String("Unknown");
            }
        }
    };
}