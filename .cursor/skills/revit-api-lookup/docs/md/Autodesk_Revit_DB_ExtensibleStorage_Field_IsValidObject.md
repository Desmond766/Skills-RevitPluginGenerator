---
kind: property
id: P:Autodesk.Revit.DB.ExtensibleStorage.Field.IsValidObject
source: html/d25061ca-e0ac-bf79-d835-d1b570a501a6.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.Field.IsValidObject Property

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

