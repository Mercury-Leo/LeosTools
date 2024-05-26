#if UNITY_EDITOR

namespace Tools.Editor.Template
{
    internal static class TemplateConfig
    {
        private const string Divider = "/";
        private const string NewClass = "new";
        private const string Template = "Template";

        private const string CreationPath = "Assets/Create/Templates/";
        private const string ClassExtension = ".cs";
        private const string TemplatesFolder = "Templates";
        private const string TemplateExtension = ClassExtension + ".txt";

        private const string Interface = "Interface";
        public const string InterfaceItem = CreationPath + Interface;
        public const string InterfaceClass = NewClass + Interface + ClassExtension;
        public const string InterfaceTemplate = TemplatesFolder + Divider + Interface + Template + TemplateExtension;

        private const string ScriptableObject = "ScriptableObject";
        public const string ScriptableObjectItem = CreationPath + ScriptableObject;
        public const string ScriptableObjectClass = NewClass + ScriptableObject + ClassExtension;

        public const string ScriptableObjectTemplate =
            TemplatesFolder + Divider + ScriptableObject + Template + TemplateExtension;

        private const string Class = "Class";
        public const string ClassItem = CreationPath + Class;
        public const string PureClass = NewClass + Class + ClassExtension;
        public const string ClassTemplate = TemplatesFolder + Divider + Class + Template + TemplateExtension;

        private const string StaticClass = "StaticClass";
        public const string StaticClassItem = CreationPath + StaticClass;
        public const string StaticClassClass = NewClass + StaticClass + ClassExtension;

        public const string StaticClassTemplate =
            TemplatesFolder + Divider + StaticClass + Template + TemplateExtension;

        private const string Enum = "Enum";
        public const string EnumItem = CreationPath + Enum;
        public const string EnumClass = NewClass + Enum + ClassExtension;
        public const string EnumTemplate = TemplatesFolder + Divider + Enum + Template + TemplateExtension;
    }
}

#endif