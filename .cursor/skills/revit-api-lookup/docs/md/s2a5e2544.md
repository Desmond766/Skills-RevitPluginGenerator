---
kind: property
id: P:Autodesk.Revit.DB.AssemblyInstance.AssemblyTypeName
source: html/182e1b2e-a25d-4597-ef28-68df80023a5d.htm
---
# Autodesk.Revit.DB.AssemblyInstance.AssemblyTypeName Property

The name for the assembly type.
 All matching assembly instances share this name.
 Unique assembly instances are named automatically based on their naming category.

## Syntax (C#)
```csharp
public string AssemblyTypeName { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: This assembly type name is not valid for this assembly instance.
 An assembly type name should be non-empty, should contain valid characters, and should be unique for its naming category.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

