---
kind: property
id: P:Autodesk.Revit.DB.RoutingCondition.IsValidObject
source: html/f831ddb6-274b-771f-68c8-7d509ba04d02.htm
---
# Autodesk.Revit.DB.RoutingCondition.IsValidObject Property

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

