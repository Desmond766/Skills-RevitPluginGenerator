---
kind: method
id: M:Autodesk.Revit.UI.UIApplication.LoadPackageContents(System.String)
source: html/dc0790b0-44ca-2db9-30af-aec18344bf00.htm
---
# Autodesk.Revit.UI.UIApplication.LoadPackageContents Method

Loads add-ins from the given packageContents.xml file.

## Syntax (C#)
```csharp
public void LoadPackageContents(
	string packageContentsPath
)
```

## Parameters
- **packageContentsPath** (`System.String`) - The name of package contents file

## Exceptions
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - Thrown when manifest file which is specified by 
packageContentsPath doesn't exist.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown if the add-in file path specified by 
packageContentsPath is null, Or packageContentsPath is null.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the add-in specified by packageContentsPath doesn't
end with 'addin' or packageContentsPath is a zero-length string.
- **Autodesk.Revit.Exceptions.FileNotFoundException** - Thrown if the packageContentsPath is not found.
- **Autodesk.Revit.Exceptions.ApplicationException** - Thrown if the manifest file specified by packageContentsPath 
can't be parsed successfully.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when any of the newly added external 
applications fails to load and/or initialize properly, possibly because of one of the following reasons:
AllowLoadingIntoExistingSession property is 'No'.Client id is duplicated.External application start up failed.
- **Autodesk.Revit.Exceptions.InternalException** - Thrown if packageContentsPath file that was found could not 
be loaded.

