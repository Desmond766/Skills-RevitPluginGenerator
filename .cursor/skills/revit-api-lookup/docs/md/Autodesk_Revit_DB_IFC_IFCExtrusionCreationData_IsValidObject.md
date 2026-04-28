---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCExtrusionCreationData.IsValidObject
source: html/51dcad87-fd8f-4776-ed1c-e9cdd6dd808f.htm
---
# Autodesk.Revit.DB.IFC.IFCExtrusionCreationData.IsValidObject Property

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

