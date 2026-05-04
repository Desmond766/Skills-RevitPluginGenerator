---
kind: property
id: P:Autodesk.Revit.DB.TransactWithCentralOptions.IsValidObject
source: html/234aeb18-41e1-fba3-c03a-5ebd2fc179dd.htm
---
# Autodesk.Revit.DB.TransactWithCentralOptions.IsValidObject Property

Specifies whether the .NET object represents a valid Revit entity.

## Syntax (C#)
```csharp
public bool IsValidObject { get; }
```

## Returns
True if the API object holds a valid Revit native object, false otherwise.

## Remarks
If the corresponding Revit native object is destroyed, or creation of the corresponding object is undone,
 a managed API object containing it is no longer valid. API methods cannot be called on invalidated wrapper objects.

