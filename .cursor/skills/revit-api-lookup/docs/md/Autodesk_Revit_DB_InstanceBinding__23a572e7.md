---
kind: type
id: T:Autodesk.Revit.DB.InstanceBinding
source: html/7978cb57-0a48-489e-2c8f-116fa2561437.htm
---
# Autodesk.Revit.DB.InstanceBinding

The InstanceBinding object is used to signify a binding between a parameter
definition and a parameter on each instance of an element, such as a wall.

## Syntax (C#)
```csharp
public class InstanceBinding : ElementBinding
```

## Remarks
Once bound the parameter will appear on all instance of the element and changing
the parameter on any one single instance will not change the value on any other instance.

