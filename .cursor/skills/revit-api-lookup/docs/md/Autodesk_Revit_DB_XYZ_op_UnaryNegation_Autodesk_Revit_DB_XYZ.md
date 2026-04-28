---
kind: method
id: M:Autodesk.Revit.DB.XYZ.op_UnaryNegation(Autodesk.Revit.DB.XYZ)
zh: 点
source: html/c9c8953a-7999-cc2b-3dc5-d27e2229563a.htm
---
# Autodesk.Revit.DB.XYZ.op_UnaryNegation Method

**中文**: 点

Negates the specified vector and returns the result.

## Syntax (C#)
```csharp
public static XYZ operator -(
	XYZ source
)
```

## Parameters
- **source** (`Autodesk.Revit.DB.XYZ`)

## Returns
The vector opposite to the specified vector.

## Remarks
The negated vector is obtained by changing the sign of each coordinate 
of the specified vector.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when source is Nothing nullptr a null reference ( Nothing in Visual Basic) .

