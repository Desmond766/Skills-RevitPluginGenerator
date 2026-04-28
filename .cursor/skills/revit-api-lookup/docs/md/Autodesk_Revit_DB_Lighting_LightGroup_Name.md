---
kind: property
id: P:Autodesk.Revit.DB.Lighting.LightGroup.Name
source: html/9a98f8c4-2c7b-5fa3-098d-eaff98cc5dd7.htm
---
# Autodesk.Revit.DB.Lighting.LightGroup.Name Property

The name of the LightGroup

## Syntax (C#)
```csharp
public string Name { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 When setting this property: The name is not valid because it is not unique within this LightGroupManager
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

