---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.UnloadItemFiles(System.Collections.Generic.IList{Autodesk.Revit.DB.FabricationItemFile})
source: html/3343cdd7-7050-0e6f-c294-936a3a9c7e03.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.UnloadItemFiles Method

Unload the specified fabrication item files from the project.

## Syntax (C#)
```csharp
public void UnloadItemFiles(
	IList<FabricationItemFile> itemFiles
)
```

## Parameters
- **itemFiles** (`System.Collections.Generic.IList < FabricationItemFile >`) - The fabrication item files to unload.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Fabrication item files can not be unloaded if they are currently in use.
 -or-
 Some fabrication item files have not been loaded.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The current fabrication configuration is not connected and updated to source configuration. Reload and try again.

