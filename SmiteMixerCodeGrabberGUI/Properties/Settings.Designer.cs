﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmiteMixerCodeGrabberGUI.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool notificationSetting {
            get {
                return ((bool)(this["notificationSetting"]));
            }
            set {
                this["notificationSetting"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AFKMode {
            get {
                return ((bool)(this["AFKMode"]));
            }
            set {
                this["AFKMode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool whitelistOnly {
            get {
                return ((bool)(this["whitelistOnly"]));
            }
            set {
                this["whitelistOnly"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("17")]
        public int codeLength {
            get {
                return ((int)(this["codeLength"]));
            }
            set {
                this["codeLength"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("AP")]
        public string codesStartWith {
            get {
                return ((string)(this["codesStartWith"]));
            }
            set {
                this["codesStartWith"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>ScottyBot</string>
  <string>HiRez Auvey</string>
  <string>HiRez Hinduman</string>
  <string>HiRez Finch</string>
  <string>HiRez Vinny</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection whitelistedUsernames {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["whitelistedUsernames"]));
            }
            set {
                this["whitelistedUsernames"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Beep.mp3")]
        public string notificationSoundFilePath {
            get {
                return ((string)(this["notificationSoundFilePath"]));
            }
            set {
                this["notificationSoundFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool notificationSound {
            get {
                return ((bool)(this["notificationSound"]));
            }
            set {
                this["notificationSound"] = value;
            }
        }
    }
}
