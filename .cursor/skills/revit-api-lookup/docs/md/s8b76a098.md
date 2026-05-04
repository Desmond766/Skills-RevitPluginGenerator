---
kind: property
id: P:Autodesk.Revit.DB.Architecture.NonContinuousRailInfo.Name
source: html/22b1f1ae-5d2f-3644-0c88-0f97503ed6dd.htm
---
# Autodesk.Revit.DB.Architecture.NonContinuousRailInfo.Name Property

The name of the non-continuous rail.

## Syntax (C#)
```csharp
public string Name { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: name is an empty string or contains only whitespace.
 -or-
 When setting this property: name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 When setting this property: The name name is not valid for the non-continuous rail.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

