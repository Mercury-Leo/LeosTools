#if UNITY_EDITOR

namespace Editor.Templater {
    internal static class TemplateConfig {
        const string PathDivider = "/";
        const string NewClass = "new";
        const string Template = "Template";
        const string ClassExtension = ".cs";
        const string PackagesFolder = "Packages/";
        const string TemplateFolder = "Editor/Templater/Templates/";
        const string PackageName = "com.leosclockworks.tools";
        const string CreationPath = "Assets/Create/Templates/";
        const string TemplateExtension = ClassExtension + ".txt";

        const string TemplatesPath =
            PackagesFolder + PackageName + PathDivider + TemplateFolder;

        const string Interface = "Interface";
        public const string InterfaceItem = CreationPath + Interface;
        public const string InterfaceClass = NewClass + Interface + ClassExtension;
        public const string InterfaceTemplate = TemplatesPath + Interface + Template + TemplateExtension;

        const string ScriptableObject = "ScriptableObject";
        public const string ScriptableObjectItem = CreationPath + ScriptableObject;
        public const string ScriptableObjectClass = NewClass + ScriptableObject + ClassExtension;
        public const string ScriptableObjectTemplate = TemplatesPath + ScriptableObject + Template + TemplateExtension;

        const string Class = "Class";
        public const string ClassItem = CreationPath + Class;
        public const string PureClass = NewClass + Class + ClassExtension;
        public const string ClassTemplate = TemplatesPath + Class + Template + TemplateExtension;

        const string StaticClass = "StaticClass";
        public const string StaticClassItem = CreationPath + StaticClass;
        public const string StaticClassClass = NewClass + StaticClass + ClassExtension;
        public const string StaticClassTemplate = TemplatesPath + StaticClass + Template + TemplateExtension;

        const string Enum = "Enum";
        public const string EnumItem = CreationPath + Enum;
        public const string EnumClass = NewClass + Enum + ClassExtension;
        public const string EnumTemplate = TemplatesPath + Enum + Template + TemplateExtension;
    }
}

#endif