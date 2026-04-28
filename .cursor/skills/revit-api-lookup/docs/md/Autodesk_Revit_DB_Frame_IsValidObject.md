---
kind: property
id: P:Autodesk.Revit.DB.Frame.IsValidObject
source: html/46ce3715-590e-d9b3-4ad0-a3e739961a66.htm
---
# Autodesk.Revit.DB.Frame.IsValidObject Property

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

