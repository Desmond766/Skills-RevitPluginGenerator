---
kind: method
id: M:Autodesk.Revit.DB.FabricationServiceButton.GetConditionImage(System.Int32!System.Runtime.CompilerServices.IsConst)
source: html/2fce0630-0135-1c5f-a2ac-4f6e211a9c61.htm
---
# Autodesk.Revit.DB.FabricationServiceButton.GetConditionImage Method

Gets the image for the specified fabrication service button condition.

## Syntax (C#)
```csharp
public virtual Bitmap GetConditionImage(
	int condition
)
```

## Parameters
- **condition** (`System.Int32`) - The condition index.

## Returns
System.Drawing.Bitmap represents the fabrication service button image. Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no preview image.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - the index condition is not larger or equal to 0 and less than ConditionCount

