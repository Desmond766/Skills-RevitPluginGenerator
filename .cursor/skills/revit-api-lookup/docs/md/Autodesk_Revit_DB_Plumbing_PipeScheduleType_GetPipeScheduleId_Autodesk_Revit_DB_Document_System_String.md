---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipeScheduleType.GetPipeScheduleId(Autodesk.Revit.DB.Document,System.String)
source: html/72fa88cd-5c96-bab5-e7f7-76ecd42c7e9f.htm
---
# Autodesk.Revit.DB.Plumbing.PipeScheduleType.GetPipeScheduleId Method

Returns an existing pipe schedule type with the same name.

## Syntax (C#)
```csharp
public static ElementId GetPipeScheduleId(
	Document doc,
	string name
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document
- **name** (`System.String`) - The name of requested schedule type.

## Returns
Returns the element id of request schedule type, or invalidElementId if the name is not found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

