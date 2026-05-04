---
kind: property
id: P:Autodesk.Revit.DB.RelinquishOptions.IsValidObject
source: html/ef0eed52-60f5-281c-50a7-aefec87b8f0f.htm
---
# Autodesk.Revit.DB.RelinquishOptions.IsValidObject Property

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

