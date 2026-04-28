---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCFile.CreateHeaderInstance(System.String)
source: html/0cacd649-83b8-17f2-8244-90711fbdbd61.htm
---
# Autodesk.Revit.DB.IFC.IFCFile.CreateHeaderInstance Method

Creates an IFC header instance in the file model.

## Syntax (C#)
```csharp
public IFCAnyHandle CreateHeaderInstance(
	string name
)
```

## Parameters
- **name** (`System.String`) - The instance name.

## Returns
The instance handle.

## Remarks
file_schema, file_description and file_name
 must be created to get IFC file written successfully.
 Otherwise, the output IFC file would be empty.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

