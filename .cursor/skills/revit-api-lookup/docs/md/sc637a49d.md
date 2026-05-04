---
kind: method
id: M:Autodesk.Revit.DB.SchedulableField.GetName(Autodesk.Revit.DB.Document)
source: html/b217ab1e-3027-c5a1-10dc-49912b313562.htm
---
# Autodesk.Revit.DB.SchedulableField.GetName Method

Gets the name of the field.

## Syntax (C#)
```csharp
public string GetName(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the field will be used.

## Returns
The name of the field.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The parameter doesn't exist in document.

