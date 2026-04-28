---
kind: property
id: P:Autodesk.Revit.DB.Architecture.BalusterInfo.Name
source: html/1702a973-7eef-87ac-ddca-720b65c1948b.htm
---
# Autodesk.Revit.DB.Architecture.BalusterInfo.Name Property

The name of the baluster.

## Syntax (C#)
```csharp
public string Name { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: name is an empty string or contains only whitespace.
 -or-
 When setting this property: name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

