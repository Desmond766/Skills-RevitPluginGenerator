---
kind: property
id: P:Autodesk.Revit.DB.ParameterValue.IsValidObject
source: html/b3c38be8-8464-b650-b352-a917a4c13ddd.htm
---
# Autodesk.Revit.DB.ParameterValue.IsValidObject Property

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

