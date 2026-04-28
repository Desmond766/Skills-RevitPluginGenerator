---
kind: property
id: P:Autodesk.Revit.DB.ContourSetting.IsValidObject
source: html/85b91877-0f04-5bef-872e-4b2dc97d4cf5.htm
---
# Autodesk.Revit.DB.ContourSetting.IsValidObject Property

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

