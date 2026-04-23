using Autodesk.Revit.UI;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Annotations;
using System.Windows.Media.Imaging;

namespace Demo02
{
    internal class Ribbon : IExternalApplication
    {
        //当前dll文件的完整路径
        static string AddinPath = typeof(Ribbon).Assembly.Location;
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            application.CreateRibbonTab("CEG Tools");
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("CEG Tools", "Tag");
            PushButtonData createTags = new PushButtonData("Create Tags", "Create Structural\nFramework Tags", AddinPath, "Demo02.Command02");
            createTags.ToolTip = "Batch create tags based on the selected structural framework.";
            createTags.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("Demo02.dll", "icon/createTags.png")));
            ribbonPanel.AddItem(createTags);

            PushButtonData createSpecialityEquipmentTags = new PushButtonData("Create Speciality Equipment Tags", "Create Speciality\nEquipment Tags", AddinPath, "Demo02.Command03");
            createSpecialityEquipmentTags.ToolTip = "Create dedicated device tags for all dedicated devices in this view.";
            createSpecialityEquipmentTags.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("Demo02.dll", "icon/createSpecialityEquipmentTags.png")));
            ribbonPanel.AddItem(createSpecialityEquipmentTags);

            RibbonPanel ribbonPanel1 = application.CreateRibbonPanel("CEG Tools", "Dimension");
            PushButtonData createDimensions = new PushButtonData("Create Dimensions", "Place Dimensions", AddinPath, "Demo02.Command");
            createDimensions.ToolTip = "Batch create dimensions based on selected family instances.";
            createDimensions.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("Demo02.dll", "icon/createDimensions.png")));
            ribbonPanel1.AddItem(createDimensions);

            RibbonPanel ribbonPanel2 = application.CreateRibbonPanel("CEG Tools", "Other");
            PushButtonData viewTemplateBrush = new PushButtonData("View Template Brush", "View Template\nBrush", AddinPath, "Demo02.Command04");
            viewTemplateBrush.ToolTip = "Copy the view template of a viewport.";
            viewTemplateBrush.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("Demo02.dll", "icon/viewTemplateBrush.png")));
            ribbonPanel2.AddItem(viewTemplateBrush);
            
            PushButtonData workPoint = new PushButtonData("Work Point", "Work Point", AddinPath, "Demo02.Command05");
            workPoint.ToolTip = "Draw the embedded work points for slope arrangement.";
            workPoint.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("Demo02.dll", "icon/workPoint.png")));
            ribbonPanel2.AddItem(workPoint);
            
            PushButtonData arrangeSuspensionComponents = new PushButtonData("Arrange Suspension\nComponents", "Arrange Suspension\nComponents", AddinPath, "Demo02.Command06");
            arrangeSuspensionComponents.ToolTip = "Multi point arrangement of suspension components side lifter.";
            arrangeSuspensionComponents.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("Demo02.dll", "icon/arrangeSuspensionComponents.png")));
            ribbonPanel2.AddItem(arrangeSuspensionComponents);
            
            PushButtonData findOverlappingEmbeddedParts = new PushButtonData("Find Overlapping\nEmbedded Parts", "Find Overlapping\nEmbedded Parts", AddinPath, "Demo02.Class20");
            findOverlappingEmbeddedParts.ToolTip = "Find Overlapping Embedded Parts.";
            findOverlappingEmbeddedParts.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("Demo02.dll", "icon/findOverlappingEmbeddedParts.png")));
            ribbonPanel2.AddItem(findOverlappingEmbeddedParts);
            
            PushButtonData updateModelParameters = new PushButtonData("Update Model\nParameters", "Update Model\nParameters", AddinPath, "Demo02.Command08");
            updateModelParameters.ToolTip = "Update the model schedule based on the Excel spreadsheet (fill in the corresponding parameter values), such as ticket state, description, and plate information.";
            updateModelParameters.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("Demo02.dll", "icon/updateModelParameters.png")));
            ribbonPanel2.AddItem(updateModelParameters);
            
            PushButtonData generateSteelBars = new PushButtonData("Generate Steel\nBars", "Generate Steel\nBars", AddinPath, "Demo02.Command09");
            generateSteelBars.ToolTip = "Click on the sleeves placed vertically on two planes to generate L-shaped or straight steel bars.";
            generateSteelBars.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("Demo02.dll", "icon/generateSteelBars.png")));
            ribbonPanel2.AddItem(generateSteelBars);
            
            PushButtonData extendDetailLine = new PushButtonData("Extend Detail\nLine", "Extend Detail\nLine", AddinPath, "Demo02.Command07");
            extendDetailLine.ToolTip = "Extend the detailed drawing line to the structural framework.";
            extendDetailLine.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("Demo02.dll", "icon/extendDetailLine.png")));
            ribbonPanel2.AddItem(extendDetailLine);
            
            PushButtonData textAnnotations = new PushButtonData("Creating Text\nAnnotations", "Creating Text\nAnnotations", AddinPath, "Demo02.Command10");
            textAnnotations.ToolTip = "Obtain the parameters of the selected family instance and create a text annotation at the specified location.";
            textAnnotations.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("Demo02.dll", "icon/textAnnotations.png")));
            ribbonPanel2.AddItem(textAnnotations);
            
            PushButtonData gridSettings = new PushButtonData("Grid Settings", "Grid Settings", AddinPath, "Demo02.Command11");
            gridSettings.ToolTip = "Set all grid single-sided numbering display and 2/3D properties.";
            gridSettings.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("Demo02.dll", "icon/gridSettings.png")));
            ribbonPanel2.AddItem(gridSettings);
            
            PushButtonData extendingSteelBars = new PushButtonData("Extending steel\nbars", "Extending steel\nbars", AddinPath, "Demo02.Command12");
            extendingSteelBars.ToolTip = "Set the length of the steel bar from one side to the selected surface.";
            extendingSteelBars.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("Demo02.dll", "icon/extendingSteelBars.png")));
            ribbonPanel2.AddItem(extendingSteelBars);





            return Result.Succeeded;
        }
    }
}
