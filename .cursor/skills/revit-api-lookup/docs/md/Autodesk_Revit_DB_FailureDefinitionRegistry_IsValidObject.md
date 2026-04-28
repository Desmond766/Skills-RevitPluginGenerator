---
kind: property
id: P:Autodesk.Revit.DB.FailureDefinitionRegistry.IsValidObject
source: html/8c8964df-f1f9-6cc6-cc26-442b99803e40.htm
---
# Autodesk.Revit.DB.FailureDefinitionRegistry.IsValidObject Property

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

