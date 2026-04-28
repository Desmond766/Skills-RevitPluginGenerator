---
kind: property
id: P:Autodesk.Revit.DB.AssemblyInstance.NamingCategoryId
source: html/5a4c70fa-83cc-d594-2dda-84f3386ceae7.htm
---
# Autodesk.Revit.DB.AssemblyInstance.NamingCategoryId Property

Id of the category that drives the default naming scheme for the assembly instance.

## Syntax (C#)
```csharp
public ElementId NamingCategoryId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: This naming category was not valid for an assembly instance containing the proposed members.
 The naming category should match one of the member element categories.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

