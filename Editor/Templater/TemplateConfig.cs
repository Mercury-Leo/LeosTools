#if UNITY_EDITOR

namespace Tools.Editor.Template
{
    internal static class TemplateConfig
    {
        private const string PathDivider = "/";
        private const string NewClass = "new";
        private const string Template = "Template";
        private const string ClassExtension = ".cs";
        private const string PackagesFolder = "Packages/";
        private const string TemplateFolder = "Editor/Templater/Templates/";
        private const string PackageName = "com.leosclockworks.tools";
        private const string CreationPath = "Assets/Create/Templates/";
        private const string TemplateExtension = ClassExtension + ".txt";

        private const string TemplatesPath =
            PackagesFolder + PackageName + PathDivider + TemplateFolder;

        private const string Interface = "Interface";
        public const string InterfaceItem = CreationPath + Interface;
        public const string InterfaceClass = NewClass + Interface + ClassExtension;
        public const string InterfaceTemplate = TemplatesPath + Interface + Template + TemplateExtension;

        private const string ScriptableObject = "ScriptableObject";
        public const string ScriptableObjectItem = CreationPath + ScriptableObject;
        public const string ScriptableObjectClass = NewClass + ScriptableObject + ClassExtension;
        public const string ScriptableObjectTemplate = TemplatesPath + ScriptableObject + Template + TemplateExtension;

        private const string Class = "Class";
        public const string ClassItem = CreationPath + Class;
        public const string PureClass = NewClass + Class + ClassExtension;
        public const string ClassTemplate = TemplatesPath + Class + Template + TemplateExtension;

        private const string StaticClass = "StaticClass";
        public const string StaticClassItem = CreationPath + StaticClass;
        public const string StaticClassClass = NewClass + StaticClass + ClassExtension;
        public const string StaticClassTemplate = TemplatesPath + StaticClass + Template + TemplateExtension;

        private const string Enum = "Enum";
        public const string EnumItem = CreationPath + Enum;
        public const string EnumClass = NewClass + Enum + ClassExtension;
        public const string EnumTemplate = TemplatesPath + Enum + Template + TemplateExtension;
    }
}

#endif