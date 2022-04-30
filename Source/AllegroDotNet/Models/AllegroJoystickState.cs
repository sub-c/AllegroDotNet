using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
  public sealed class AllegroJoystickState
  {
    // implement properties/indexers to read buttons, axii, and sticks...

    internal NativeJoystickState JoystickState = new();

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NativeJoystickState
    {
      public float stick0_axis0;
      public float stick0_axis1;
      public float stick0_axis2;
      public float stick1_axis0;
      public float stick1_axis1;
      public float stick1_axis2;
      public float stick2_axis0;
      public float stick2_axis1;
      public float stick2_axis2;
      public float stick3_axis0;
      public float stick3_axis1;
      public float stick3_axis2;
      public float stick4_axis0;
      public float stick4_axis1;
      public float stick4_axis2;
      public float stick5_axis0;
      public float stick5_axis1;
      public float stick5_axis2;
      public float stick6_axis0;
      public float stick6_axis1;
      public float stick6_axis2;
      public float stick7_axis0;
      public float stick7_axis1;
      public float stick7_axis2;
      public float stick8_axis0;
      public float stick8_axis1;
      public float stick8_axis2;
      public float stick9_axis0;
      public float stick9_axis1;
      public float stick9_axis2;
      public float stick10_axis0;
      public float stick10_axis1;
      public float stick10_axis2;
      public float stick11_axis0;
      public float stick11_axis1;
      public float stick11_axis2;
      public float stick12_axis0;
      public float stick12_axis1;
      public float stick12_axis2;
      public float stick13_axis0;
      public float stick13_axis1;
      public float stick13_axis2;
      public float stick14_axis0;
      public float stick14_axis1;
      public float stick14_axis2;
      public float stick15_axis0;
      public float stick15_axis1;
      public float stick15_axis2;

      public int button0;
      public int button1;
      public int button2;
      public int button3;
      public int button4;
      public int button5;
      public int button6;
      public int button7;
      public int button8;
      public int button9;
      public int button10;
      public int button11;
      public int button12;
      public int button13;
      public int button14;
      public int button15;
      public int button16;
      public int button17;
      public int button18;
      public int button19;
      public int button20;
      public int button21;
      public int button22;
      public int button23;
      public int button24;
      public int button25;
      public int button26;
      public int button27;
      public int button28;
      public int button29;
      public int button30;
      public int button31;
    }
  }
}