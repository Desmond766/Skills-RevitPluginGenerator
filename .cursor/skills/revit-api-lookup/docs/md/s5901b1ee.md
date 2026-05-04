---
kind: property
id: P:Autodesk.Revit.UI.FilterDialog.NewFilterName
source: html/9f823665-bd01-f303-b5cd-8e20f02c2e62.htm
---
# Autodesk.Revit.UI.FilterDialog.NewFilterName Property

The name of the new ParameterFilterElement to be created and selected once Show is invoked.

## Syntax (C#)
```csharp
public string NewFilterName { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: newFilterName is an empty string.
 -or-
 When setting this property: newFilterName cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 When setting this property: The supplied filter name newFilterName is not unique.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

