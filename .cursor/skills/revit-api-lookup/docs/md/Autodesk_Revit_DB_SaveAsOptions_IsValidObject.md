---
kind: property
id: P:Autodesk.Revit.DB.SaveAsOptions.IsValidObject
source: html/a1a3f9aa-1970-0f43-6881-ad400f0c2a9b.htm
---
# Autodesk.Revit.DB.SaveAsOptions.IsValidObject Property

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

