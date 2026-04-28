---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSetting.RemoveWireType(Autodesk.Revit.DB.Electrical.WireType)
source: html/2a4cbba1-f777-47b5-e3c2-941950f172ba.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSetting.RemoveWireType Method

Remove wire type definition from project.

## Syntax (C#)
```csharp
public void RemoveWireType(
	WireType wireType
)
```

## Parameters
- **wireType** (`Autodesk.Revit.DB.Electrical.WireType`)

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Wire type can be removed only if it is not used, otherwise an exception will be thrown.

