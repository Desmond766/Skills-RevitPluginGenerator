---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.CanUnloadItemFiles(System.Collections.Generic.IList{Autodesk.Revit.DB.FabricationItemFile})
source: html/eaece08e-f3cf-3bd6-489e-19d8cf8e8b1f.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.CanUnloadItemFiles Method

Checks if the fabrication item files are already in use and should not be unloaded.

## Syntax (C#)
```csharp
public bool CanUnloadItemFiles(
	IList<FabricationItemFile> itemFiles
)
```

## Parameters
- **itemFiles** (`System.Collections.Generic.IList < FabricationItemFile >`) - The fabrication item files to unload.

## Returns
Returns true if the fabrication item files can be unloaded, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

