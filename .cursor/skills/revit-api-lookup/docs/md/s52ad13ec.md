---
kind: method
id: M:Autodesk.Revit.DB.UV.Add(Autodesk.Revit.DB.UV)
source: html/b7c4255f-91b8-f28f-a2fc-1780212acdd3.htm
---
# Autodesk.Revit.DB.UV.Add Method

Adds the specified 2-D vector to this 2-D vector and returns the result.

## Syntax (C#)
```csharp
public UV Add(
	UV source
)
```

## Parameters
- **source** (`Autodesk.Revit.DB.UV`) - The vector to add to this vector.

## Returns
The 2-D vector equal to the sum of the two vectors.

## Remarks
The added vector is obtained by adding each coordinate of the specified vector
to the corresponding coordinate of this vector.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when source is Nothing nullptr a null reference ( Nothing in Visual Basic) .

