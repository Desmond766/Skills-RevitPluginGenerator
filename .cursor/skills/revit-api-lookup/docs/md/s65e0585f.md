---
kind: method
id: M:Autodesk.Revit.DB.UV.op_UnaryNegation(Autodesk.Revit.DB.UV)
source: html/b83a1321-860e-f7ef-dbc3-780bb7bea69b.htm
---
# Autodesk.Revit.DB.UV.op_UnaryNegation Method

Negates this 2-D vector and returns the result.

## Syntax (C#)
```csharp
public static UV operator -(
	UV source
)
```

## Parameters
- **source** (`Autodesk.Revit.DB.UV`)

## Returns
The 2-D vector opposite to this vector.

## Remarks
The negated vector is obtained by changing the sign of each coordinate 
of the specified vector.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when source is Nothing nullptr a null reference ( Nothing in Visual Basic) .

