---
kind: method
id: M:Autodesk.Revit.DB.Transform2D.TransformUVDomainIfPossible(Autodesk.Revit.DB.BoundingBoxUV)
source: html/977e71c5-7a76-a4ee-5232-f826a00f7471.htm
---
# Autodesk.Revit.DB.Transform2D.TransformUVDomainIfPossible Method

Transforms an envelope ( BoundingBoxUV ) for one surface to an envelope for a coincident but differently parameterized surface.

## Syntax (C#)
```csharp
public BoundingBoxUV TransformUVDomainIfPossible(
	BoundingBoxUV uvDomain
)
```

## Parameters
- **uvDomain** (`Autodesk.Revit.DB.BoundingBoxUV`) - The original surface envelope.

## Returns
If successful a new BoundingBoxUV transformed surface envelope, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
This method succeeds in the case when the uv-parameter transform between the surfaces
 has a simple form, that commonly occurs for analytic surfaces,
 such that the image of the input envelope under the transform
 is itself a rectangular region aligned with the UV coordinate axes.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - uvDomain is not set.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

