---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.LoadItemFiles(System.Collections.Generic.IList{Autodesk.Revit.DB.FabricationItemFile})
source: html/d7aa286a-d55d-46da-b654-0c175f433abc.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.LoadItemFiles Method

Loads the specified fabrication item files into the project.

## Syntax (C#)
```csharp
public IList<FabricationItemFile> LoadItemFiles(
	IList<FabricationItemFile> itemFiles
)
```

## Parameters
- **itemFiles** (`System.Collections.Generic.IList < FabricationItemFile >`) - The relative paths of the fabrication item files to load.

## Returns
The relative paths of the fabrication item files which failed to load.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The current fabrication configuration is not connected and updated to source configuration. Reload and try again.
 -or-
 this operation failed.

