---
kind: property
id: P:Autodesk.Revit.DB.TransmissionData.IsValidObject
source: html/2f060c6b-ec06-aced-2898-7fcd1bf2f522.htm
---
# Autodesk.Revit.DB.TransmissionData.IsValidObject Property

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

