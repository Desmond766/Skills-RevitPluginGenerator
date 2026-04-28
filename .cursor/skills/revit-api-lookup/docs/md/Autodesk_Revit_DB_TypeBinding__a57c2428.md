---
kind: type
id: T:Autodesk.Revit.DB.TypeBinding
source: html/f5066ef5-fa12-4cd2-ad0c-ca72ab21e479.htm
---
# Autodesk.Revit.DB.TypeBinding

TypeBinding objects are used to bind a property to a Revit type, such as a wall type.

## Syntax (C#)
```csharp
public class TypeBinding : ElementBinding
```

## Remarks
This differs from Instance bindings in that the property is then shared by all
instances that use that type. Changing the parameter for one type affects all other
instances that use that type.

