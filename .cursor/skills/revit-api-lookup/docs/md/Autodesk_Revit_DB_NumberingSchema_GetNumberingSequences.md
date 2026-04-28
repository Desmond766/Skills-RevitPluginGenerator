---
kind: method
id: M:Autodesk.Revit.DB.NumberingSchema.GetNumberingSequences
source: html/0eea26e0-24c0-154b-b7ac-c24b47eafa96.htm
---
# Autodesk.Revit.DB.NumberingSchema.GetNumberingSequences Method

Returns all numbering sequences within this numbering schema.

## Syntax (C#)
```csharp
public IList<string> GetNumberingSequences()
```

## Returns
A collection of partition names of all numbering sequences currently present in this schema.

## Remarks
The collection may be empty if there are no elements yet in this schema. One of the strings can be an empty string, which would indicate presence
 of the default partition into which elements automatically belong if left
 unassigned to any other partition

