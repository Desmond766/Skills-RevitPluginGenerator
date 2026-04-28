---
kind: property
id: P:Autodesk.Revit.DB.Connector.Angle
zh: 连接件、接口
source: html/852cc933-8cba-9050-b441-fbbd035a5576.htm
---
# Autodesk.Revit.DB.Connector.Angle Property

**中文**: 连接件、接口

The angle of the Connector.

## Syntax (C#)
```csharp
public double Angle { get; set; }
```

## Remarks
Angle may be assigned for connectors of some family instances.
In order to set this property, it must be mapped to a writable instance parameter in the family definition.
For a connector obtained from a non-family instance (for example not a fitting, but instead a pipe, duct, or 
cable tray), the value will always be zero. Non-zero angles are only valid for family instance fitting connectors.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector's domain is not DomainHvac, DomainPiping, or DomainCableTrayConduit.
Thrown when set value for the connector not in family instance.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when setting an invalid value.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to set angle.

