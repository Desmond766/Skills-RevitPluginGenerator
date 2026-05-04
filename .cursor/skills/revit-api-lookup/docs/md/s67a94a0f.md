---
kind: property
id: P:Autodesk.Revit.DB.Visual.AssetProperty.IsValidObject
source: html/81e8a4a9-ad56-09e5-bcf8-9801a24dd636.htm
---
# Autodesk.Revit.DB.Visual.AssetProperty.IsValidObject Property

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

