---
kind: property
id: P:Autodesk.Revit.UI.UIApplication.IsValidObject
source: html/564c625f-fa6b-e6df-9cdb-8319f0f403b0.htm
---
# Autodesk.Revit.UI.UIApplication.IsValidObject Property

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

