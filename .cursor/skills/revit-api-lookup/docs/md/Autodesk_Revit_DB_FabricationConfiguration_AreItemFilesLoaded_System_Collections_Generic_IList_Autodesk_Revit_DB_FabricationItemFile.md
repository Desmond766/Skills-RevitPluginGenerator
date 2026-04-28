---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.AreItemFilesLoaded(System.Collections.Generic.IList{Autodesk.Revit.DB.FabricationItemFile})
source: html/bdedf16d-79ae-abd0-9052-697366004b19.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.AreItemFilesLoaded Method

Checks if the fabrication item files have been loaded.

## Syntax (C#)
```csharp
public bool AreItemFilesLoaded(
	IList<FabricationItemFile> itemFiles
)
```

## Parameters
- **itemFiles** (`System.Collections.Generic.IList < FabricationItemFile >`) - The fabrication item files.

## Returns
Returns true if the fabrication item files have been loaded, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

