﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoreTechs.Common.Std.Tests.Text {
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class TestFiles {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TestFiles() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CoreTechs.Common.Std.Tests.Text.TestFiles", typeof(TestFiles).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;A,B,C&quot;,&quot;D,E,F&quot;
        ///&quot;G,H,I&quot;,&quot;J,K,L&quot;
        ///&quot;Ronnie &quot;&quot;Dwanye&quot;&quot; Overby&quot;,&quot;&quot;&quot;Tiner&quot;&quot; Overby&quot;,&quot;&quot;&quot;THIS&quot;&quot;,
        ///&quot;&quot;THAT&quot;&quot;,
        ///&quot;&quot;THE OTHER!&quot;&quot;&quot;.
        /// </summary>
        internal static string AdvancedTextQualified {
            get {
                return ResourceManager.GetString("AdvancedTextQualified", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ,
        ///A,
        ///,B
        ///,C,
        ///,D,E,
        ///,F,,G,
        ///,, ,.
        /// </summary>
        internal static string EmptyFields {
            get {
                return ResourceManager.GetString("EmptyFields", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to   Ronnie  ,  Overby  
        ///  &quot;  Tina  &quot;, &quot;  Overby  &quot;
        ///  &quot;  Anna  &quot; &quot;  Lukus  &quot;  .
        /// </summary>
        internal static string FieldDataIsTrimmed {
            get {
                return ResourceManager.GetString("FieldDataIsTrimmed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A,B,C
        ///D,E,F.
        /// </summary>
        internal static string Simple {
            get {
                return ResourceManager.GetString("Simple", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;A&quot;,&quot;B&quot;,&quot;C&quot;
        ///&quot;D&quot;,&quot;E&quot;,&quot;F&quot;.
        /// </summary>
        internal static string SimpleTextQualified {
            get {
                return ResourceManager.GetString("SimpleTextQualified", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name, Age, Gender, Employer
        ///Ronnie, 30, Male, Core Techs
        ///Tina, 30, Female, HPU
        ///Lukus,8,Male,
        ///Anna,3,Female.
        /// </summary>
        internal static string WithHeader {
            get {
                return ResourceManager.GetString("WithHeader", resourceCulture);
            }
        }
    }
}
