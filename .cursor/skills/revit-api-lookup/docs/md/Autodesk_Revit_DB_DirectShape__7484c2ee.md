---
kind: type
id: T:Autodesk.Revit.DB.DirectShape
source: html/bfbd137b-c2c2-71bb-6f4a-992d0dcf6ea8.htm
---
# Autodesk.Revit.DB.DirectShape

This class is used to store externally created geometric shapes. Primary intended use is for importing shapes from other data formats such as IFC or STEP.
 A DirectShape object may be assigned a category. That will affect how that object is displayed in Revit.

## Syntax (C#)
```csharp
public class DirectShape : Element
```

## Remarks
DirectShape is not a replacement for "real" Wall, Roof, Window, etc. It would typically be used where there is not enough information
 to create, e.g., a Wall, or full functionality of a Wall object is not needed. Some category-specific functionality may be available.
If you need to modify a shape held by a DirectShape object, use Revit Geometry API, and then store the modified shape back to the DirectShape object.

