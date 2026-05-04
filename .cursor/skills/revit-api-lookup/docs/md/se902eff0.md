---
kind: property
id: P:Autodesk.Revit.DB.DirectShapeReferenceOptions.Name
source: html/e264772c-2a00-b937-171b-684d33c487d3.htm
---
# Autodesk.Revit.DB.DirectShapeReferenceOptions.Name Property

The name associated with the reference object.
 The name does not need to be unique.
 The name must not be empty and must contain valid characters.

## Syntax (C#)
```csharp
public string Name { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: value cannot be used as a name for the direct shape reference.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

