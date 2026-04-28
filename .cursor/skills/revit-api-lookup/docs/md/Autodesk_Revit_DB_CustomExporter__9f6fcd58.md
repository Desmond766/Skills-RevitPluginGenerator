---
kind: type
id: T:Autodesk.Revit.DB.CustomExporter
source: html/d2437433-9183-cbb1-1c67-dedd86db5b5a.htm
---
# Autodesk.Revit.DB.CustomExporter

A class that allows exporting 3D or 2D views via an export context.

## Syntax (C#)
```csharp
public class CustomExporter : IDisposable
```

## Remarks
The Export method of this class triggers standard rendering or exporting
 process in Revit, but instead of displaying the result on screen or printer,
 the output is channeled through the given custom context that handles
 processing of the geometric as well as non-geometric information.
Revit will process the exporting algorithm depending on the type
 of given context. If an instance of IPhotoRenderContext 
 is used, then Revit will output the model as if executing the Render command,
 thus only such entities that would be visible in a rendered view
 will be sent to the context.
Alternatively, if an instance of IModelExportContext 
 is used, Revit will output the model as if exporting it to a CAD format,
 a process which results outputting also objects that would not
 appear in a rendered image, such as model curves and text annotations.
For 2D views, an instance of IExportContext2D 
 has to be used. Revit will output the contents of the 2D view as it is displayed on the screen.
 Export can be modified by setting properties pertaining to 2D views:
 Export2DGeometricObjectsIncludingPatternLines ,
 Export2DIncludingAnnotationObjects .
 Export2DForceDisplayStyle .
See notes for 2D export in IExportContext2D .

