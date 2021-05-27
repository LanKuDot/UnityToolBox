using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace LanKuDot.UnityToolBox.CameraUtils
{
    /// <summary>
    /// Take a photo from the target camera
    /// </summary>
    public class CameraPhoto : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        private RenderTexture _renderTexture;
        private RenderTexture _origRenderTexture;
        private int _pixelWidth;
        private int _pixelHeight;
        private Action<Texture2D> _onTaken;

        private void Reset()
        {
            _camera = GetComponent<Camera>();
        }

        /// <summary>
        /// Take the photo from the target camera
        /// </summary>
        /// <param name="width">The width in pixel of the target photo</param>
        /// <param name="height">The height in pixel of the target photo</param>
        /// <param name="onTaken">The callback to be invoked when the photo is taken</param>
        public void TakeAPhoto(
            int width, int height, Action<Texture2D> onTaken)
        {
            _pixelWidth = width;
            _pixelHeight = height;
            _onTaken = onTaken;

            ActivateCamera();
        }

        private void OnEndCameraRendering(ScriptableRenderContext context, Camera camera)
        {
            if (camera != _camera)
                return;

            _onTaken?.Invoke(CaptureCamera());
            InactivateCamera();
        }

        /// <summary>
        /// Capture the rendered frame and store to the texture
        /// </summary>
        /// <returns>The created texture</returns>
        private Texture2D CaptureCamera()
        {
            var texture =
                new Texture2D(
                    _pixelWidth, _pixelHeight, TextureFormat.ARGB32, false);
            texture.ReadPixels(new Rect(0, 0, _pixelWidth, _pixelHeight), 0, 0);
            texture.Apply();
            return texture;
        }

        #region Activation

        /// <summary>
        /// Activate the camera for rendering a frame to the render texture
        /// </summary>
        private void ActivateCamera()
        {
            _origRenderTexture = _camera.targetTexture;
            _renderTexture =
                RenderTexture.GetTemporary(_pixelWidth, _pixelHeight, 16);
            _camera.targetTexture = _renderTexture;

            RenderPipelineManager.endCameraRendering += OnEndCameraRendering;
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Inactivate the camera and release the created render texture
        /// </summary>
        private void InactivateCamera()
        {
            _camera.targetTexture = _origRenderTexture;
            RenderTexture.ReleaseTemporary(_renderTexture);

            RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
            gameObject.SetActive(false);
        }

        #endregion
    }
}
