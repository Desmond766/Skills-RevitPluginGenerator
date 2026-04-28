---
kind: property
id: P:Autodesk.Revit.DB.ExternalService.ExternalServices.BuiltInExternalServices.TemporaryGraphicsHandlerService
source: html/6a94cec2-eabe-8669-e851-7ddbb7b2425c.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalServices.BuiltInExternalServices.TemporaryGraphicsHandlerService Property

The external service Id which permits registration of an callback handler for temporary graphics objects managed by [!:Autodesk::Revit::DB::TemporaryGraphicsManager] .
 To use this service, developers implement a server class that derives from [!:Autodesk::Revit::UI::ITemporaryGraphicsHandler] .

## Syntax (C#)
```csharp
public static ExternalServiceId TemporaryGraphicsHandlerService { get; }
```

