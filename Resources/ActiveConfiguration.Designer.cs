﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Musicbar.Resources {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class ActiveConfiguration : global::System.Configuration.ApplicationSettingsBase {
        
        private static ActiveConfiguration defaultInstance = ((ActiveConfiguration)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new ActiveConfiguration())));
        
        public static ActiveConfiguration Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("bluesky")]
        public string Theme {
            get {
                return ((string)(this["Theme"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CTRL+F4")]
        public string PlayPauseHotkey {
            get {
                return ((string)(this["PlayPauseHotkey"]));
            }
        }
    }
}
