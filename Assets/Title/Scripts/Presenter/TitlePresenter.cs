using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Title.Model;
using Title.View;
using Title.Common;
using Title.Audio;
using Title.Template;

namespace Title.Presenter
{
    /// <summary>
    /// プレゼンタ
    /// タイトルシーン
    /// </summary>
    public class TitlePresenter : MonoBehaviour, ITitleGameManager
    {
        /// <summary>PushGameStartのビュー</summary>
        [SerializeField] private PushGameStartLogoView pushGameStartLogoView;
        /// <summary>PushGameStartのモデル</summary>
        [SerializeField] private PushGameStartLogoModel pushGameStartLogoModel;
        /// <summary>GameStartLogoのビュー</summary>
        [SerializeField] private GameStartLogoView gameStartLogoView;
        /// <summary>GameStartLogoのモデル</summary>
        [SerializeField] private GameStartLogoModel gameStartLogoModel;
        /// <summary>GameExitLogoのビュー</summary>
        [SerializeField] private GameExitLogoView gameExitLogoView;
        /// <summary>GameExitLogoのモデル</summary>
        [SerializeField] private GameExitLogoModel gameExitLogoModel;
        /// <summary>GameExitConfirmYesLogoのビュー</summary>
        [SerializeField] private GameExitConfirmYesLogoView gameExitConfirmYesLogoView;
        /// <summary>GameExitConfirmYesLogoのモデル</summary>
        [SerializeField] private GameExitConfirmYesLogoModel gameExitConfirmYesLogoModel;
        /// <summary>GameExitConfirmNoLogoのビュー</summary>
        [SerializeField] private GameExitConfirmNoLogoView gameExitConfirmNoLogoView;
        /// <summary>GameExitConfirmNoLogoのモデル</summary>
        [SerializeField] private GameExitConfirmNoLogoModel gameExitConfirmNoLogoModel;
        /// <summary>CursorIconのビュー</summary>
        [SerializeField] private CursorIconView cursorIconView;
        /// <summary>CursorIconのモデル</summary>
        [SerializeField] private CursorIconModel cursorIconModel;
        /// <summary>FadeImageのビュー</summary>
        [SerializeField] private FadeImageView fadeImageView;
        /// <summary>Fadeimageのモデル</summary>
        [SerializeField] private FadeImageModel fadeImageModel;
        /// <summary>BGMタイトル、スライダー、設定値の表示用パネルのビュー</summary>
        [SerializeField] private UIEventController bgmView;
        /// <summary>BGMスライダーのビュー</summary>
        [SerializeField] private SliderBgmView sliderBgmView;
        /// <summary>BGMスライダーのモデル</summary>
        [SerializeField] private SliderBgmModel sliderBgmModel;
        /// <summary>BGMスライダーの設定値のビュー</summary>
        [SerializeField] private UIEventController valueBgmView;
        /// <summary>BGMスライダーボリュームのモデル</summary>
        [SerializeField] private SliderVolModelsBgm[] sliderVolModelsBgms;
        /// <summary>SEタイトル、スライダー、設定値の表示用パネルのビュー</summary>
        [SerializeField] private UIEventController seView;
        /// <summary>SEスライダーのビュー</summary>
        [SerializeField] private SliderSeView sliderSeView;
        /// <summary>SEスライダーのモデル</summary>
        [SerializeField] private SliderSeModel sliderSeModel;
        /// <summary>SEスライダーの設定値のビュー</summary>
        [SerializeField] private UIEventController valueSeView;
        /// <summary>SEスライダーボリュームのモデル</summary>
        [SerializeField] private SliderVolModelsSe[] sliderVolModelsSes;
        /// <summary>バイブレーション機能ラジオボタンのモデル</summary>
        [SerializeField] private UIEventController radioVibrationModel;
        /// <summary>バイブレーション機能ラジオボタンのONのモデル</summary>
        [SerializeField] private UIEventController onVibrationModel;
        /// <summary>バイブレーション機能ラジオボタンのOFFのモデル</summary>
        [SerializeField] private UIEventController offVibrationModel;
        /// <summary>オプション設定リセットのボタンのモデル</summary>
        [SerializeField] private UIEventController resetConfigModel;
        /// <summary>セーブデータ消去ボタンのモデル</summary>
        [SerializeField] private UIEventController resetSaveDataModel;
        /// <summary>戻るボタンのモデル</summary>
        [SerializeField] private UIEventController backModel;
        /// <summary>オプション設定項目選択のカーソルのビュー</summary>
        [SerializeField] private UIEventController optionCursorView;
        /// <summary>オプション設定項目選択のカーソル（小）のビュー</summary>
        [SerializeField] private UIEventController optionSmallCursorView;
        /// <summary>「はい」ボタンのモデル</summary>
        [SerializeField] private UIEventController resetConfigConfirmYesModel;
        /// <summary>「はい」ボタンのビュー</summary>
        [SerializeField] private UIEventController resetConfigConfirmYesView;
        /// <summary>「いいえ」ボタンのモデル</summary>
        [SerializeField] private UIEventController resetConfigConfirmNoModel;
        /// <summary>「いいえ」ボタンのビュー</summary>
        [SerializeField] private UIEventController resetConfigConfirmNoView;
        /// <summary>「はい」ボタンのモデル</summary>
        [SerializeField] private UIEventController resetSaveDataConfirmYesModel;
        /// <summary>「はい」ボタンのビュー</summary>
        [SerializeField] private UIEventController resetSaveDataConfirmYesView;
        /// <summary>「いいえ」ボタンのモデル</summary>
        [SerializeField] private UIEventController resetSaveDataConfirmNoModel;
        /// <summary>「いいえ」ボタンのビュー</summary>
        [SerializeField] private UIEventController resetSaveDataConfirmNoView;

        private void Reset()
        {
            pushGameStartLogoView = GameObject.Find("PushGameStartLogo").GetComponent<PushGameStartLogoView>();
            pushGameStartLogoModel = GameObject.Find("PushGameStartLogo").GetComponent<PushGameStartLogoModel>();
            gameStartLogoView = GameObject.Find("GameStartLogo").GetComponent<GameStartLogoView>();
            gameStartLogoModel = GameObject.Find("GameStartLogo").GetComponent<GameStartLogoModel>();
            gameExitLogoView = GameObject.Find("GameExitLogo").GetComponent<GameExitLogoView>();
            gameExitLogoModel = GameObject.Find("GameExitLogo").GetComponent<GameExitLogoModel>();
            gameExitConfirmYesLogoView = GameObject.Find("GameExitConfirmYesLogo").GetComponent<GameExitConfirmYesLogoView>();
            gameExitConfirmYesLogoModel = GameObject.Find("GameExitConfirmYesLogo").GetComponent<GameExitConfirmYesLogoModel>();
            gameExitConfirmNoLogoView = GameObject.Find("GameExitConfirmNoLogo").GetComponent<GameExitConfirmNoLogoView>();
            gameExitConfirmNoLogoModel = GameObject.Find("GameExitConfirmNoLogo").GetComponent<GameExitConfirmNoLogoModel>();
            cursorIconView = GameObject.Find("CursorIcon").GetComponent<CursorIconView>();
            cursorIconModel = GameObject.Find("CursorIcon").GetComponent<CursorIconModel>();
            fadeImageView = GameObject.Find("FadeImage").GetComponent<FadeImageView>();
            fadeImageModel = GameObject.Find("FadeImage").GetComponent<FadeImageModel>();
            bgmView = GameObject.Find("BGM").GetComponent<UIEventController>();
            sliderBgmView = GameObject.Find("SliderBgm").GetComponent<SliderBgmView>();
            sliderBgmModel = GameObject.Find("SliderBgm").GetComponent<SliderBgmModel>();
            valueBgmView = GameObject.Find("ValueBgm").GetComponent<UIEventController>();
            List<SliderVolModelsBgm> sliderVolModelsBgmList = new List<SliderVolModelsBgm>();
            foreach (Transform child in GameObject.Find("SliderBgm").transform.GetChild(3))
                sliderVolModelsBgmList.Add(child.GetComponent<SliderVolModelsBgm>());
            sliderVolModelsBgms = sliderVolModelsBgmList.ToArray();
            seView = GameObject.Find("SE").GetComponent<UIEventController>();
            sliderSeView = GameObject.Find("SliderSe").GetComponent<SliderSeView>();
            sliderSeModel = GameObject.Find("SliderSe").GetComponent<SliderSeModel>();
            valueSeView = GameObject.Find("ValueSe").GetComponent<UIEventController>();
            List<SliderVolModelsSe> sliderVolModelsSeList = new List<SliderVolModelsSe>();
            foreach (Transform child in GameObject.Find("SliderSe").transform.GetChild(3))
                sliderVolModelsSeList.Add(child.GetComponent<SliderVolModelsSe>());
            sliderVolModelsSes = sliderVolModelsSeList.ToArray();
            radioVibrationModel = GameObject.Find("RadioVibration").GetComponent<UIEventController>();
            onVibrationModel = GameObject.Find("OnVibration").GetComponent<UIEventController>();
            offVibrationModel = GameObject.Find("OffVibration").GetComponent<UIEventController>();
            resetConfigModel = GameObject.Find("ResetConfig").GetComponent<UIEventController>();
            resetSaveDataModel = GameObject.Find("ResetSaveData").GetComponent<UIEventController>();
            backModel = GameObject.Find("Back").GetComponent<UIEventController>();
            optionCursorView = GameObject.Find("OptionCursor").GetComponent<UIEventController>();
            optionSmallCursorView = GameObject.Find("OptionSmallCursor").GetComponent<UIEventController>();
            resetConfigConfirmYesModel = GameObject.Find("ResetConfigConfirmYes").GetComponent<UIEventController>();
            resetConfigConfirmYesView = GameObject.Find("ResetConfigConfirmYes").GetComponent<UIEventController>();
            resetConfigConfirmNoModel = GameObject.Find("ResetConfigConfirmNo").GetComponent<UIEventController>();
            resetConfigConfirmNoView = GameObject.Find("ResetConfigConfirmNo").GetComponent<UIEventController>();
            resetSaveDataConfirmYesModel = GameObject.Find("ResetSaveDataConfirmYes").GetComponent<UIEventController>();
            resetSaveDataConfirmYesView = GameObject.Find("ResetSaveDataConfirmYes").GetComponent<UIEventController>();
            resetSaveDataConfirmNoModel = GameObject.Find("ResetSaveDataConfirmNo").GetComponent<UIEventController>();
            resetSaveDataConfirmNoView = GameObject.Find("ResetSaveDataConfirmNo").GetComponent<UIEventController>();
        }

        public void OnStart()
        {
            // 動的に制御するパネルをキャッシュ
            var pushGameStart = pushGameStartLogoView.transform.parent.gameObject;
            var gameStartOrExit = gameStartLogoView.transform.parent.gameObject;
            var gameExitConfirm = gameExitConfirmYesLogoView.transform.parent.gameObject;
            var cursorIcon = cursorIconView.gameObject;
            var fadeImage = fadeImageView.transform.parent.gameObject;
            // 初期設定
            pushGameStart.SetActive(false);
            gameStartOrExit.SetActive(false);
            gameExitConfirm.SetActive(false);
            cursorIcon.SetActive(false);
            fadeImage.SetActive(true);
            bgmView.transform.parent.gameObject.SetActive(false);
            optionCursorView.gameObject.SetActive(false);
            optionSmallCursorView.gameObject.SetActive(false);
            // BGMを再生
            TitleGameManager.Instance.AudioOwner.PlayBGM(ClipToPlayBGM.bgm_title);
            // シーン読み込み時のアニメーション
            Observable.FromCoroutine<bool>(observer => fadeImageView.PlayFadeAnimation(observer, EnumFadeState.Open))
                .Subscribe(_ =>
                {
                    // UI操作を許可
                    pushGameStart.SetActive(true);
                    if (!pushGameStartLogoModel.OnStart())
                        Debug.LogError("PushGameStart開始イベント呼び出しの失敗");
                })
                .AddTo(gameObject);
            // プッシュゲームスタート
            pushGameStartLogoModel.EventState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    switch ((EnumEventCommand)x)
                    {
                        case EnumEventCommand.Default:
                            // 処理無し
                            break;
                        case EnumEventCommand.Selected:
                            // 処理無し
                            break;
                        case EnumEventCommand.DeSelected:
                            // 処理無し
                            break;
                        case EnumEventCommand.AnyKeysPushed:
                            // ゲーム開始／終了UIを表示
                            pushGameStart.SetActive(false);
                            gameStartOrExit.SetActive(true);
                            if (!cursorIcon.activeSelf)
                                cursorIcon.SetActive(true);
                            if (!cursorIconView.SetSelect(gameStartLogoView.transform.position))
                                Debug.LogError("カーソル選択位置変更処理呼び出しの失敗");
                            // ゲームスタートSEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_game_start);
                            break;
                        case EnumEventCommand.Submited:
                            // 処理無し
                            break;
                        case EnumEventCommand.Canceled:
                            // 処理無し
                            break;
                        default:
                            Debug.LogWarning("例外ケース");
                            break;
                    }
                });
            // カーソル
            cursorIconView.IsAnimationPlaying.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    if (x)
                    {
                        // ボタン制御を無効
                        gameStartLogoModel.SetButtonEnabled(false);
                        gameStartLogoModel.SetEventTriggerEnabled(false);
                        gameExitLogoModel.SetButtonEnabled(false);
                        gameExitConfirmYesLogoModel.SetButtonEnabled(false);
                        gameExitConfirmYesLogoModel.SetEventTriggerEnabled(false);
                        gameExitConfirmNoLogoModel.SetButtonEnabled(false);
                    }
                    else
                    {
                        // ボタン制御を有効
                        gameStartLogoModel.SetButtonEnabled(true);
                        gameStartLogoModel.SetEventTriggerEnabled(true);
                        gameExitLogoModel.SetButtonEnabled(true);
                        gameExitConfirmYesLogoModel.SetButtonEnabled(true);
                        gameExitConfirmYesLogoModel.SetEventTriggerEnabled(true);
                        gameExitConfirmNoLogoModel.SetButtonEnabled(true);
                    }
                });
            // ゲームを開始
            gameStartLogoModel.EventState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    switch ((EnumEventCommand)x)
                    {
                        case EnumEventCommand.Default:
                            // 処理無し
                            break;
                        case EnumEventCommand.Selected:
                            if (!cursorIconView.PlaySelectAnimation(gameStartLogoView.transform.position))
                                Debug.LogError("カーソル選択アニメーション呼び出しの失敗");
                            // 選択SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_select);
                            break;
                        case EnumEventCommand.DeSelected:
                            // 処理無し
                            break;
                        case EnumEventCommand.Canceled:
                            cursorIcon.SetActive(false);
                            gameStartOrExit.SetActive(false);
                            pushGameStart.SetActive(true);
                            // キャンセルSEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_cancel);
                            break;
                        case EnumEventCommand.Submited:
                            gameStartLogoModel.SetButtonEnabled(false);
                            gameStartLogoModel.SetEventTriggerEnabled(false);
                            // 決定SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_decided);
                            // ステージセレクトへの遷移を実装
                            Observable.FromCoroutine<bool>(observer => fadeImageView.PlayFadeAnimation(observer, EnumFadeState.Close))
                                .Subscribe(_ => TitleGameManager.Instance.SceneOwner.LoadNextScene())
                                .AddTo(gameObject);
                            break;
                        default:
                            Debug.LogWarning("例外ケース");
                            break;
                    }
                });
            // ゲームを終了
            gameExitLogoModel.EventState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    switch ((EnumEventCommand)x)
                    {
                        case EnumEventCommand.Default:
                            // 処理無し
                            break;
                        case EnumEventCommand.Selected:
                            if (!cursorIconView.PlaySelectAnimation(gameExitLogoView.transform.position))
                                Debug.LogError("カーソル選択アニメーション呼び出しの失敗");
                            // 選択SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_select);
                            break;
                        case EnumEventCommand.DeSelected:
                            // 処理無し
                            break;
                        case EnumEventCommand.Canceled:
                            cursorIcon.SetActive(false);
                            gameStartOrExit.SetActive(false);
                            pushGameStart.SetActive(true);
                            // キャンセルSEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_cancel);
                            break;
                        case EnumEventCommand.Submited:
                            gameStartOrExit.SetActive(false);
                            gameExitConfirm.SetActive(true);
                            if (!cursorIconView.SetSelect(gameExitConfirmYesLogoView.transform.position))
                                Debug.LogError("カーソル選択位置変更処理呼び出しの失敗");
                            // 決定SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_decided);
                            break;
                        default:
                            Debug.LogWarning("例外ケース");
                            break;
                    }
                });
            // ゲームを終了しますか？　＞　はい
            gameExitConfirmYesLogoModel.EventState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    switch ((EnumEventCommand)x)
                    {
                        case EnumEventCommand.Default:
                            // 処理無し
                            break;
                        case EnumEventCommand.Selected:
                            if (!cursorIconView.PlaySelectAnimation(gameExitConfirmYesLogoView.transform.position))
                                Debug.LogError("カーソル選択アニメーション呼び出しの失敗");
                            // 選択SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_select);
                            break;
                        case EnumEventCommand.DeSelected:
                            // 処理無し
                            break;
                        case EnumEventCommand.Canceled:
                            gameExitConfirm.SetActive(false);
                            gameStartOrExit.SetActive(true);
                            if (!cursorIconView.SetSelect(gameStartLogoView.transform.position))
                                Debug.LogError("カーソル選択位置変更処理呼び出しの失敗");
                            // キャンセルSEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_cancel);
                            break;
                        case EnumEventCommand.Submited:
                            gameExitConfirmYesLogoModel.SetButtonEnabled(false);
                            gameExitConfirmYesLogoModel.SetEventTriggerEnabled(false);
                            // 決定SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_decided);
                            Observable.FromCoroutine<bool>(observer => fadeImageView.PlayFadeAnimation(observer, EnumFadeState.Close))
                                .Subscribe(_ => TitleGameManager.Instance.CallGameExit())
                                .AddTo(gameObject);
                            break;
                        default:
                            Debug.LogWarning("例外ケース");
                            break;
                    }
                });
            // ゲームを終了しますか？　＞　いいえ
            gameExitConfirmNoLogoModel.EventState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    switch ((EnumEventCommand)x)
                    {
                        case EnumEventCommand.Default:
                            // 処理無し
                            break;
                        case EnumEventCommand.Selected:
                            if (!cursorIconView.PlaySelectAnimation(gameExitConfirmNoLogoView.transform.position))
                                Debug.LogError("カーソル選択アニメーション呼び出しの失敗");
                            // 選択SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_select);
                            break;
                        case EnumEventCommand.DeSelected:
                            // 処理無し
                            break;
                        case EnumEventCommand.Canceled:
                            gameExitConfirm.SetActive(false);
                            gameStartOrExit.SetActive(true);
                            if (!cursorIconView.SetSelect(gameStartLogoView.transform.position))
                                Debug.LogError("カーソル選択位置変更処理呼び出しの失敗");
                            // キャンセルSEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_cancel);
                            break;
                        case EnumEventCommand.Submited:
                            gameExitConfirm.SetActive(false);
                            gameStartOrExit.SetActive(true);
                            if (!cursorIconView.SetSelect(gameStartLogoView.transform.position))
                                Debug.LogError("カーソル選択位置変更処理呼び出しの失敗");
                            // キャンセルSEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_cancel);
                            break;
                        default:
                            Debug.LogWarning("例外ケース");
                            break;
                    }
                });
            // オプション機能
            var tTResources = new TitleTemplateResourcesAccessory();
            var datas = tTResources.LoadSaveDatasCSV(ConstResorcesNames.SYSTEM_CONFIG);
            var configMap = tTResources.GetSystemConfig(datas);

            // BGMスライダー
            sliderBgmModel.EventState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    switch ((EnumEventCommand)x)
                    {
                        case EnumEventCommand.Default:
                            // 処理無し
                            break;
                        case EnumEventCommand.Selected:
                            // BGMスライダーボリュームの設定値を選択する
                            if (!sliderVolModelsBgms[sliderBgmModel.Index.Value].Select())
                                Debug.LogError("選択する呼び出しの失敗");
                            // T.B.D カーソル選択
                            //if (!optionCursorView.PlaySelectAnimation(sliderBgmView.transform.position))
                            //    Debug.LogError("カーソル選択アニメーション呼び出しの失敗");
                            break;
                        case EnumEventCommand.DeSelected:
                            // 処理無し
                            break;
                        case EnumEventCommand.Canceled:
                            // 処理無し
                            break;
                        case EnumEventCommand.Submited:
                            // 処理無し
                            break;
                        default:
                            Debug.LogWarning("例外ケース");
                            break;
                    }
                });
            sliderBgmModel.Index.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    if (!sliderBgmView.SetSliderValue(x))
                        Debug.LogError("スライダーの値セット呼び出しの失敗");
                });
            // BGMスライダーボリューム
            for (var i = 0; i < sliderVolModelsBgms.Length; i++)
            {
                var tmpIdx = i;
                sliderVolModelsBgms[tmpIdx].EventState.ObserveEveryValueChanged(x => x.Value)
                    .Subscribe(x =>
                    {
                        switch ((EnumEventCommand)x)
                        {
                            case EnumEventCommand.Default:
                                // 処理無し
                                break;
                            case EnumEventCommand.Selected:
                                // 選択SEを再生
                                TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_select);
                                if (!sliderBgmModel.SetIndex(tmpIdx))
                                    Debug.LogError("インデックス番号をセット処理呼び出しの失敗");
                                configMap[EnumSystemConfig.BGMVolumeIndex] = tmpIdx;
                                if (!TitleGameManager.Instance.AudioOwner.SetVolume(configMap))
                                    Debug.LogError("ボリュームセット処理呼び出しの失敗");
                                break;
                            case EnumEventCommand.DeSelected:
                                // 処理無し
                                break;
                            case EnumEventCommand.Canceled:
                                // 処理無し
                                break;
                            case EnumEventCommand.Submited:
                                // 処理無し
                                break;
                            default:
                                Debug.LogWarning("例外ケース");
                                break;
                        }
                    });
            }
            // SEスライダー
            sliderSeModel.EventState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    switch ((EnumEventCommand)x)
                    {
                        case EnumEventCommand.Default:
                            // 処理無し
                            break;
                        case EnumEventCommand.Selected:
                            // SEスライダーボリュームの設定値を選択する
                            if (!sliderVolModelsSes[sliderSeModel.Index.Value].Select())
                                Debug.LogError("選択する呼び出しの失敗");
                            // T.B.D カーソル選択
                            //if (!optionCursorView.PlaySelectAnimation(sliderSeView.transform.position))
                            //    Debug.LogError("カーソル選択アニメーション呼び出しの失敗");
                            break;
                        case EnumEventCommand.DeSelected:
                            // 処理無し
                            break;
                        case EnumEventCommand.Canceled:
                            // 処理無し
                            break;
                        case EnumEventCommand.Submited:
                            // 処理無し
                            break;
                        default:
                            Debug.LogWarning("例外ケース");
                            break;
                    }
                });
            sliderSeModel.Index.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    if (!sliderSeView.SetSliderValue(x))
                        Debug.LogError("スライダーの値セット呼び出しの失敗");
                });
            // SEスライダーボリューム
            for (var i = 0; i < sliderVolModelsSes.Length; i++)
            {
                var tmpIdx = i;
                sliderVolModelsSes[tmpIdx].EventState.ObserveEveryValueChanged(x => x.Value)
                    .Subscribe(x =>
                    {
                        switch ((EnumEventCommand)x)
                        {
                            case EnumEventCommand.Default:
                                // 処理無し
                                break;
                            case EnumEventCommand.Selected:
                                // 選択SEを再生
                                TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_select);
                                if (!sliderSeModel.SetIndex(tmpIdx))
                                    Debug.LogError("インデックス番号をセット処理呼び出しの失敗");
                                configMap[EnumSystemConfig.SEVolumeIndex] = tmpIdx;
                                if (!TitleGameManager.Instance.AudioOwner.SetVolume(configMap))
                                    Debug.LogError("ボリュームセット処理呼び出しの失敗");
                                break;
                            case EnumEventCommand.DeSelected:
                                // 処理無し
                                break;
                            case EnumEventCommand.Canceled:
                                // 処理無し
                                break;
                            case EnumEventCommand.Submited:
                                // 処理無し
                                break;
                            default:
                                Debug.LogWarning("例外ケース");
                                break;
                        }
                    });
            }
            // バイブレーション機能ラジオボタン
            radioVibrationModel.EventState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    switch ((EnumEventCommand)x)
                    {
                        case EnumEventCommand.Default:
                            // 処理無し
                            break;
                        case EnumEventCommand.Selected:
                            // T.B.D バイブレーション機能ラジオボタンのON/OFFの設定値を選択する
                            //if (!sliderVolModelsSes[sliderSeModel.Index.Value].Select())
                            //    Debug.LogError("選択する呼び出しの失敗");
                            // T.B.D カーソル選択
                            //if (!optionCursorView.PlaySelectAnimation(radioVibrationView.transform.position))
                            //    Debug.LogError("カーソル選択アニメーション呼び出しの失敗");
                            break;
                        case EnumEventCommand.DeSelected:
                            // 処理無し
                            break;
                        case EnumEventCommand.Canceled:
                            // 処理無し
                            break;
                        case EnumEventCommand.Submited:
                            // 処理無し
                            break;
                        default:
                            Debug.LogWarning("例外ケース");
                            break;
                    }
                });
            // バイブレーション機能ラジオボタンのON
            onVibrationModel.EventState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    switch ((EnumEventCommand)x)
                    {
                        case EnumEventCommand.Default:
                            // 処理無し
                            break;
                        case EnumEventCommand.Selected:
                            // 選択SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_select);
                            configMap[EnumSystemConfig.VibrationEnableIndex] = (int)EnumVibrationEnableState.ON;
                            if (!TitleGameManager.Instance.InputSystemsOwner.PlayVibration())
                                Debug.LogError("振動の再生処理呼び出しの失敗");
                            break;
                        case EnumEventCommand.DeSelected:
                            // 処理無し
                            break;
                        case EnumEventCommand.Canceled:
                            // 処理無し
                            break;
                        case EnumEventCommand.Submited:
                            // 処理無し
                            break;
                        default:
                            Debug.LogWarning("例外ケース");
                            break;
                    }
                });
            // バイブレーション機能ラジオボタンのOFF
            offVibrationModel.EventState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    switch ((EnumEventCommand)x)
                    {
                        case EnumEventCommand.Default:
                            // 処理無し
                            break;
                        case EnumEventCommand.Selected:
                            // 選択SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_select);
                            configMap[EnumSystemConfig.VibrationEnableIndex] = (int)EnumVibrationEnableState.OFF;
                            break;
                        case EnumEventCommand.DeSelected:
                            // 処理無し
                            break;
                        case EnumEventCommand.Canceled:
                            // 処理無し
                            break;
                        case EnumEventCommand.Submited:
                            // 処理無し
                            break;
                        default:
                            Debug.LogWarning("例外ケース");
                            break;
                    }
                });
            // オプション設定リセットのボタン
            resetConfigModel.EventState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    switch ((EnumEventCommand)x)
                    {
                        case EnumEventCommand.Default:
                            // 処理無し
                            break;
                        case EnumEventCommand.Selected:
                            // 選択SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_select);
                            // T.B.D カーソル選択
                            //if (!optionCursorView.PlaySelectAnimation(resetConfigView.transform.position))
                            //    Debug.LogError("カーソル選択アニメーション呼び出しの失敗");
                            break;
                        case EnumEventCommand.DeSelected:
                            // 処理無し
                            break;
                        case EnumEventCommand.Canceled:
                            // 処理無し
                            break;
                        case EnumEventCommand.Submited:
                            // 決定SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_decided);
                            // オプション設定リセット＞オプション設定リセットしますか？を有効
                            resetConfigConfirmYesView.transform.parent.gameObject.SetActive(true);
                            // オプション設定項目選択のカーソル（小）を有効
                            optionSmallCursorView.gameObject.SetActive(true);
                            // T.B.D カーソル選択
                            //if (!optionSmallCursorView.SetSelect(resetConfigConfirmYesView.transform.position))
                            //    Debug.LogError("カーソル選択位置変更処理呼び出しの失敗");
                            break;
                        default:
                            Debug.LogWarning("例外ケース");
                            break;
                    }
                });
            // セーブデータ消去ボタン
            resetSaveDataModel.EventState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    switch ((EnumEventCommand)x)
                    {
                        case EnumEventCommand.Default:
                            // 処理無し
                            break;
                        case EnumEventCommand.Selected:
                            // 選択SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_select);
                            // T.B.D カーソル選択
                            //if (!optionCursorView.PlaySelectAnimation(resetSaveDataView.transform.position))
                            //    Debug.LogError("カーソル選択アニメーション呼び出しの失敗");
                            break;
                        case EnumEventCommand.DeSelected:
                            // 処理無し
                            break;
                        case EnumEventCommand.Canceled:
                            // 処理無し
                            break;
                        case EnumEventCommand.Submited:
                            // 決定SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_decided);
                            // セーブデータ消去＞セーブデータ消去しますか？を有効
                            resetSaveDataConfirmYesView.transform.parent.gameObject.SetActive(true);
                            // オプション設定項目選択のカーソル（小）を有効
                            optionSmallCursorView.gameObject.SetActive(true);
                            // T.B.D カーソル選択
                            //if (!optionSmallCursorView.SetSelect(resetSaveDataConfirmYesView.transform.position))
                            //    Debug.LogError("カーソル選択位置変更処理呼び出しの失敗");
                            break;
                        default:
                            Debug.LogWarning("例外ケース");
                            break;
                    }
                });
            // 戻るボタン
            backModel.EventState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    switch ((EnumEventCommand)x)
                    {
                        case EnumEventCommand.Default:
                            // 処理無し
                            break;
                        case EnumEventCommand.Selected:
                            // 選択SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_select);
                            // T.B.D カーソル選択
                            //if (!optionCursorView.PlaySelectAnimation(backView.transform.position))
                            //    Debug.LogError("カーソル選択アニメーション呼び出しの失敗");
                            break;
                        case EnumEventCommand.DeSelected:
                            // 処理無し
                            break;
                        case EnumEventCommand.Canceled:
                            // 処理無し
                            break;
                        case EnumEventCommand.Submited:
                            // キャンセルSEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_cancel);
                            // T.B.D オプション設定を閉じる
                            bgmView.transform.parent.gameObject.SetActive(false);
                            break;
                        default:
                            Debug.LogWarning("例外ケース");
                            break;
                    }
                });
            // オプション設定リセット＞オプション設定リセットしますか？＞「はい」
            resetConfigConfirmYesModel.EventState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    switch ((EnumEventCommand)x)
                    {
                        case EnumEventCommand.Default:
                            // 処理無し
                            break;
                        case EnumEventCommand.Selected:
                            // 選択SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_select);
                            // T.B.D カーソル選択
                            //if (!optionSmallCursorView.PlaySelectAnimation(resetConfigConfirmYesView.transform.position))
                            //    Debug.LogError("カーソル選択アニメーション呼び出しの失敗");
                            break;
                        case EnumEventCommand.DeSelected:
                            // 処理無し
                            break;
                        case EnumEventCommand.Canceled:
                            // キャンセルSEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_cancel);
                            // オプション設定リセット＞オプション設定リセットしますか？を無効
                            resetConfigConfirmYesView.transform.parent.gameObject.SetActive(false);
                            // オプション設定項目選択のカーソル（小）を無効
                            optionSmallCursorView.gameObject.SetActive(false);
                            //if (!resetConfigModel.Select())
                            //    Debug.LogError("選択する呼び出しの失敗");
                            break;
                        case EnumEventCommand.Submited:
                            // 決定SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_decided);
                            var datas = tTResources.LoadResourcesCSV(ConstResorcesNames.SYSTEM_CONFIG);
                            var configMap = tTResources.GetSystemConfig(datas);
                            if (!tTResources.SaveDatasCSVOfSystemConfig(ConstResorcesNames.SYSTEM_CONFIG, configMap))
                                Debug.LogError("システムオプション設定をCSVデータへ保存処理呼び出しの失敗");
                            if (!TitleGameManager.Instance.AudioOwner.ReLoadAudios())
                                Debug.LogError("オーディオ情報をリロード処理呼び出しの失敗");
                            // オプション設定リセット＞オプション設定リセットしますか？を無効
                            resetConfigConfirmYesView.transform.parent.gameObject.SetActive(false);
                            // オプション設定項目選択のカーソル（小）を無効
                            optionSmallCursorView.gameObject.SetActive(false);
                            //if (!resetConfigModel.Select())
                            //    Debug.LogError("選択する呼び出しの失敗");
                            break;
                        default:
                            Debug.LogWarning("例外ケース");
                            break;
                    }
                });
            // オプション設定リセット＞オプション設定リセットしますか？＞「いいえ」
            resetConfigConfirmNoModel.EventState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    switch ((EnumEventCommand)x)
                    {
                        case EnumEventCommand.Default:
                            // 処理無し
                            break;
                        case EnumEventCommand.Selected:
                            // 選択SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_select);
                            // T.B.D カーソル選択
                            //if (!optionSmallCursorView.PlaySelectAnimation(resetConfigConfirmNoView.transform.position))
                            //    Debug.LogError("カーソル選択アニメーション呼び出しの失敗");
                            break;
                        case EnumEventCommand.DeSelected:
                            // 処理無し
                            break;
                        case EnumEventCommand.Canceled:
                            // キャンセルSEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_cancel);
                            // オプション設定リセット＞オプション設定リセットしますか？を無効
                            resetConfigConfirmYesView.transform.parent.gameObject.SetActive(false);
                            // オプション設定項目選択のカーソル（小）を無効
                            optionSmallCursorView.gameObject.SetActive(false);
                            //if (!resetConfigModel.Select())
                            //    Debug.LogError("選択する呼び出しの失敗");
                            break;
                        case EnumEventCommand.Submited:
                            // キャンセルSEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_cancel);
                            // オプション設定リセット＞オプション設定リセットしますか？を無効
                            resetConfigConfirmYesView.transform.parent.gameObject.SetActive(false);
                            // オプション設定項目選択のカーソル（小）を無効
                            optionSmallCursorView.gameObject.SetActive(false);
                            //if (!resetConfigModel.Select())
                            //    Debug.LogError("選択する呼び出しの失敗");
                            break;
                        default:
                            Debug.LogWarning("例外ケース");
                            break;
                    }
                });
            // セーブデータ消去＞セーブデータ消去しますか？＞「はい」
            resetSaveDataConfirmYesModel.EventState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    switch ((EnumEventCommand)x)
                    {
                        case EnumEventCommand.Default:
                            // 処理無し
                            break;
                        case EnumEventCommand.Selected:
                            // 選択SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_select);
                            // T.B.D カーソル選択
                            //if (!optionSmallCursorView.PlaySelectAnimation(resetSaveDataConfirmYesView.transform.position))
                            //    Debug.LogError("カーソル選択アニメーション呼び出しの失敗");
                            break;
                        case EnumEventCommand.DeSelected:
                            // 処理無し
                            break;
                        case EnumEventCommand.Canceled:
                            // キャンセルSEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_cancel);
                            // セーブデータ消去＞セーブデータ消去しますか？を無効
                            resetSaveDataConfirmYesView.transform.parent.gameObject.SetActive(false);
                            // オプション設定項目選択のカーソル（小）を無効
                            optionSmallCursorView.gameObject.SetActive(false);
                            //if (!resetSaveDataModel.Select())
                            //    Debug.LogError("選択する呼び出しの失敗");
                            break;
                        case EnumEventCommand.Submited:
                            // 決定SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_decided);
                            var datas = tTResources.LoadResourcesCSV(ConstResorcesNames.MAIN_SCENE_STAGES_STATE);
                            var configMap = tTResources.GetSystemConfig(datas);
                            if (!tTResources.SaveDatasCSVOfSystemConfig(ConstResorcesNames.MAIN_SCENE_STAGES_STATE, configMap))
                                Debug.LogError("システムオプション設定をCSVデータへ保存処理呼び出しの失敗");
                            // セーブデータ消去＞セーブデータ消去しますか？を無効
                            resetSaveDataConfirmYesView.transform.parent.gameObject.SetActive(false);
                            // オプション設定項目選択のカーソル（小）を無効
                            optionSmallCursorView.gameObject.SetActive(false);
                            //if (!resetSaveDataModel.Select())
                            //    Debug.LogError("選択する呼び出しの失敗");
                            break;
                        default:
                            Debug.LogWarning("例外ケース");
                            break;
                    }
                });
            // セーブデータ消去＞セーブデータ消去しますか？＞「いいえ」
            resetSaveDataConfirmNoModel.EventState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x =>
                {
                    switch ((EnumEventCommand)x)
                    {
                        case EnumEventCommand.Default:
                            // 処理無し
                            break;
                        case EnumEventCommand.Selected:
                            // 選択SEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_select);
                            // T.B.D カーソル選択
                            //if (!optionSmallCursorView.PlaySelectAnimation(resetSaveDataConfirmYesView.transform.position))
                            //    Debug.LogError("カーソル選択アニメーション呼び出しの失敗");
                            break;
                        case EnumEventCommand.DeSelected:
                            // 処理無し
                            break;
                        case EnumEventCommand.Canceled:
                            // キャンセルSEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_cancel);
                            // セーブデータ消去＞セーブデータ消去しますか？を無効
                            resetSaveDataConfirmYesView.transform.parent.gameObject.SetActive(false);
                            // オプション設定項目選択のカーソル（小）を無効
                            optionSmallCursorView.gameObject.SetActive(false);
                            //if (!resetSaveDataModel.Select())
                            //    Debug.LogError("選択する呼び出しの失敗");
                            break;
                        case EnumEventCommand.Submited:
                            // キャンセルSEを再生
                            TitleGameManager.Instance.AudioOwner.PlaySFX(ClipToPlay.se_cancel);
                            // セーブデータ消去＞セーブデータ消去しますか？を無効
                            resetSaveDataConfirmYesView.transform.parent.gameObject.SetActive(false);
                            // オプション設定項目選択のカーソル（小）を無効
                            optionSmallCursorView.gameObject.SetActive(false);
                            //if (!resetSaveDataModel.Select())
                            //    Debug.LogError("選択する呼び出しの失敗");
                            break;
                        default:
                            Debug.LogWarning("例外ケース");
                            break;
                    }
                });
        }
    }
}
