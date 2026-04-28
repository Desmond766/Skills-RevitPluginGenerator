---
kind: property
id: P:Autodesk.Revit.DB.FilterableValueProvider.IsValidObject
source: html/5d450813-c752-0c31-b3c2-ec9bed441e02.htm
---
# Autodesk.Revit.DB.FilterableValueProvider.IsValidObject Property

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

