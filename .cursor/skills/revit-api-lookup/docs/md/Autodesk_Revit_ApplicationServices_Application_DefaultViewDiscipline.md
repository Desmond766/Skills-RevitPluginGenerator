---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.DefaultViewDiscipline
source: html/d9ce12d4-c5be-2c3d-4770-4a091ad0ab7f.htm
---
# Autodesk.Revit.ApplicationServices.Application.DefaultViewDiscipline Property

The view discipline that will be applied to new views by default.

## Syntax (C#)
```csharp
public ViewDiscipline DefaultViewDiscipline { get; set; }
```

## Remarks
This view discipline may be overridden by a view template when a view template is also applied to new views.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This functionality is not available in Revit LT.

